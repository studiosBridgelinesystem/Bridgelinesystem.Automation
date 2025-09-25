using Bridgeline.Automation.Application.DTOs.CompanyIntegrations;
using Bridgeline.Automation.Application.Interfaces.Services;
using Bridgeline.Automation.Application.UseCases.CompanyIntegrations;

namespace Bridgeline.Automation.Application.Services
{
    public class CompanyIntegrationService : ICompanyIntegrationService
    {
        private readonly CreateCompanyIntegrationUseCase _createCompanyIntegrationUseCase;
        private readonly UpdateCompanyIntegrationUseCase _updateCompanyIntegrationUseCase;
        private readonly GetCompanyIntegrationUseCase _getCompanyIntegrationUseCase;
        private readonly GetCompanyIntegrationsUseCase _getCompanyIntegrationsUseCase;
        private readonly DeleteCompanyIntegrationUseCase _deleteCompanyIntegrationUseCase;

        public CompanyIntegrationService(
            CreateCompanyIntegrationUseCase createCompanyIntegrationUseCase,
            UpdateCompanyIntegrationUseCase updateCompanyIntegrationUseCase,
            GetCompanyIntegrationUseCase getCompanyIntegrationUseCase,
            GetCompanyIntegrationsUseCase getCompanyIntegrationsUseCase,
            DeleteCompanyIntegrationUseCase deleteCompanyIntegrationUseCase
            )
        {
            _createCompanyIntegrationUseCase = createCompanyIntegrationUseCase;
            _updateCompanyIntegrationUseCase = updateCompanyIntegrationUseCase;
            _getCompanyIntegrationUseCase = getCompanyIntegrationUseCase;
            _getCompanyIntegrationsUseCase = getCompanyIntegrationsUseCase;
            _deleteCompanyIntegrationUseCase = deleteCompanyIntegrationUseCase;
        }
        public async Task<ResponseCompanyIntegrationDto> CreateCompanyIntegrationAsync(PostCompanyIntegrationDto dto)
        {
            var data = await _createCompanyIntegrationUseCase.ExecuteAsync(dto);
            return ResponseCompanyIntegrationDto.FromEntity(data);
        }

       public async Task<ResponseCompanyIntegrationDto> UpdateCompanyIntegrationAsync(Guid id, PutCompanyIntegrationDto dto)
        {
            var data = await _updateCompanyIntegrationUseCase.ExecuteAsync(id, dto);
            return ResponseCompanyIntegrationDto.FromEntity(data);
        }
        public async Task<ResponseCompanyIntegrationDto> GetCompanyIntegrationAsync(Guid id)
        {
            var data = await _getCompanyIntegrationUseCase.ExecuteAsync(id);
            return ResponseCompanyIntegrationDto.FromEntity(data);
        }
        public async Task<List<ResponseCompanyIntegrationDto>> GetCompanyIntegrationsAsync()
        {
            var data = await _getCompanyIntegrationsUseCase.ExecuteAsync();
            return ResponseCompanyIntegrationDto.FromEntities(data);
        }
        public async Task<bool> DeleteCompanyIntegrationAsync(Guid id)
        {
            return await _deleteCompanyIntegrationUseCase.ExecuteAsync(id);
        }
    }
}
