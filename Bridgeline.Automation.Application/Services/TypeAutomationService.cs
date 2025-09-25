using Bridgeline.Automation.Application.DTOs.TypeAutomations;
using Bridgeline.Automation.Application.Interfaces.Services;
using Bridgeline.Automation.Application.UseCases.TypeAutomations;

namespace Bridgeline.Automation.Application.Services
{
    public class TypeAutomationService : ITypeAutomationService
    {
        private readonly CreateTypeAutomationUseCase _createTypeAutomationUseCase;
        private readonly UpdateTypeAutomationUseCase _updateTypeAutomationUseCase;
        private readonly GetTypeAutomationUseCase _getTypeAutomationUseCase;
        private readonly GetTypeAutomationsUseCase _getTypeAutomationsUseCase;
        private readonly DeleteTypeAutomationUseCase _deleteTypeAutomationUseCase;

        public TypeAutomationService(
            CreateTypeAutomationUseCase createTypeAutomationUseCase,
            UpdateTypeAutomationUseCase updateTypeAutomationUseCase,
            GetTypeAutomationUseCase getTypeAutomationUseCase,
            GetTypeAutomationsUseCase getTypeAutomationsUseCase,
            DeleteTypeAutomationUseCase deleteTypeAutomationUseCase
            )
        {
            _createTypeAutomationUseCase = createTypeAutomationUseCase;
            _updateTypeAutomationUseCase = updateTypeAutomationUseCase;
            _getTypeAutomationUseCase = getTypeAutomationUseCase;
            _getTypeAutomationsUseCase = getTypeAutomationsUseCase;
            _deleteTypeAutomationUseCase = deleteTypeAutomationUseCase;
        }

        public async Task<ResponseTypeAutomationDto> CreateTypeAutomationService(PostTypeAutomationDto typeAutomationDto)
        {
            var data = await _createTypeAutomationUseCase.ExecuteAsync(typeAutomationDto);
            return ResponseTypeAutomationDto.FromEntity(data);
        }

        public async Task<ResponseTypeAutomationDto> UpdateTypeAutomationService(Guid id, PutTypeAutomationDto typeAutomationDto)
        {
            var data = await _updateTypeAutomationUseCase.ExecuteAsync(id, typeAutomationDto);
            return ResponseTypeAutomationDto.FromEntity(data);
        }

        public async Task<ResponseTypeAutomationDto> GetTypeAutomationService(Guid id)
        {
            var data = await _getTypeAutomationUseCase.ExecuteAsync(id);
            return ResponseTypeAutomationDto.FromEntity(data);
        }

        public async Task<List<ResponseTypeAutomationDto>> GetTypeAutomationsService()
        {
            var data = await _getTypeAutomationsUseCase.ExecuteAsync();
            return ResponseTypeAutomationDto.FromEntities(data);
        }

        public async Task<bool> DeleteTypeAutomationService(Guid id)
        {
           return await _deleteTypeAutomationUseCase.ExecuteAsync(id);
        }

    }
}
