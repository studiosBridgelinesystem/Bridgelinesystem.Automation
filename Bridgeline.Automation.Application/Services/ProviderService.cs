using Bridgeline.Automation.Application.DTOs.Providers;
using Bridgeline.Automation.Application.Interfaces.Services;
using Bridgeline.Automation.Application.UseCases.Providers;

namespace Bridgeline.Automation.Application.Services
{
    public class ProviderService : IProviderService
    {
        private readonly CreateProviderUseCase _createProviderUseCase;
        private readonly UpdateProviderUseCase _updateProviderUseCase;
        private readonly GetProviderUseCase _getProviderUseCase;
        private readonly GetProvidersUseCase _getProvidersUseCase;
        private readonly DeleteProviderUseCase _deleteProviderUseCase;

        public ProviderService(
            CreateProviderUseCase createProviderUseCase,
            UpdateProviderUseCase updateProviderUseCase,
            GetProviderUseCase getProviderUseCase,
            GetProvidersUseCase getProvidersUseCase,
            DeleteProviderUseCase deleteProviderUseCase
            )
        {
            _createProviderUseCase = createProviderUseCase;
            _updateProviderUseCase = updateProviderUseCase;
            _getProviderUseCase = getProviderUseCase;
            _getProvidersUseCase = getProvidersUseCase;
            _deleteProviderUseCase = deleteProviderUseCase;
        }

        public async Task<ResponseProviderDto> CreateProviderAsync(PostProviderDto dto)
        {
            var data = await _createProviderUseCase.ExecuteAsync(dto);
            return ResponseProviderDto.FromEntity(data);
        }

        public async Task<ResponseProviderDto> UpdateProviderAsync(Guid id, PutProviderDto dto)
        {
            var data = await _updateProviderUseCase.ExecuteAsync(id, dto);
            return ResponseProviderDto.FromEntity(data);
        }


        public async Task<ResponseProviderDto> GetProviderAsync(Guid id)
        {
            var data = await _getProviderUseCase.ExecuteAsync(id);
            return ResponseProviderDto.FromEntity(data);
        }

        public async Task<List<ResponseProviderDto>> GetProvidersAsync()
        {
            var data = await _getProvidersUseCase.ExecuteAsync();
            return ResponseProviderDto.FromEntities(data);
        }

        public async Task<bool> DeleteProviderAsync(Guid id)
        {
            return await _deleteProviderUseCase.ExecuteAsync(id);
        }
    }
}
