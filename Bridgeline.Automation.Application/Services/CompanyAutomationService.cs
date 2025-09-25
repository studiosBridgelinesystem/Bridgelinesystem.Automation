using Bridgeline.Automation.Application.DTOs.CompanyAutomations;
using Bridgeline.Automation.Application.Interfaces.Services;
using Bridgeline.Automation.Application.UseCases.CompanyAutomations;


namespace Bridgeline.Automation.Application.Services
{
    public class CompanyAutomationService : ICompanyAutomationService
    {
        private readonly CreateCompanyAutomationUseCase _createCompanyAutomationUseCase;
        private readonly UpdateCompanyAutomationUseCase _updateCompanyAutomationUseCase;
        private readonly GetCompanyAutomationUseCase _getCompanyAutomationUseCase;
        private readonly GetCompanyAutomationsUseCase _getCompanyAutomationsUseCase;
        private readonly DeleteCompanyAutomationUseCase _deleteCompanyAutomationUseCase;

        public CompanyAutomationService(
            CreateCompanyAutomationUseCase createCompanyAutomationUseCase,
            UpdateCompanyAutomationUseCase updateCompanyAutomationUseCase,
            GetCompanyAutomationUseCase getCompanyAutomationUseCase,
            GetCompanyAutomationsUseCase getCompanyAutomationsUseCase,
            DeleteCompanyAutomationUseCase deleteCompanyAutomationUseCase
            )
        {
            _createCompanyAutomationUseCase = createCompanyAutomationUseCase;
            _updateCompanyAutomationUseCase = updateCompanyAutomationUseCase;
            _getCompanyAutomationUseCase = getCompanyAutomationUseCase;
            _getCompanyAutomationsUseCase = getCompanyAutomationsUseCase;
            _deleteCompanyAutomationUseCase = deleteCompanyAutomationUseCase;
        }

        public async Task<ResponseCompanyAutomationDto> CreateCompanyAutomationAsync(PostCompanyAutomationDto dto)
        {
            var data = await _createCompanyAutomationUseCase.ExecuteAsync(dto);
            return ResponseCompanyAutomationDto.FromEntity(data);
        }
        public async Task<ResponseCompanyAutomationDto> UpdateCompanyAutomationAsync(Guid id, PutCompanyAutomationDto dto)
        {
            var data = await _updateCompanyAutomationUseCase.ExecuteAsync(id, dto);
            return ResponseCompanyAutomationDto.FromEntity(data);
        }

        public async Task<ResponseCompanyAutomationDto> GetCompanyAutomationAsync(Guid id)
        {
            var data = await _getCompanyAutomationUseCase.ExecuteAsync(id);
            return ResponseCompanyAutomationDto.FromEntity(data);
        }

        public async Task<List<ResponseCompanyAutomationDto>> GetCompanyAutomationsAsync()
        {
            var data = await _getCompanyAutomationsUseCase.ExecuteAsync();
            return ResponseCompanyAutomationDto.FromEntities(data);
        }

        public async Task<bool> DeleteCompanyAutomationAsync(Guid id)
        {
            return await _deleteCompanyAutomationUseCase.ExecuteAsync(id);
        }
    }
}
