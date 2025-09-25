using Bridgeline.Automation.Application.DTOs.ProviderServices;
using Bridgeline.Automation.Application.Interfaces.Services;
using Bridgeline.Automation.Application.UseCases.ProviderServices;

namespace Bridgeline.Automation.Application.Services
{
    public class ProviderServicesService : IProviderServicesService
    {
        private readonly CreateProviderServicesUseCase _createProviderServicesUseCase;
        private readonly UpdateProviderServiceUseCase _updateProviderServiceUseCase;
        private readonly GetProviderServiceUseCase _getProviderServiceUseCase;
        private readonly GetProviderServicesUseCase _getProviderServicesUseCase;
        private readonly DeleteProviderServiceUseCase _deleteProviderServiceUseCase;

        public ProviderServicesService(
            CreateProviderServicesUseCase createProviderServicesUseCase,
            UpdateProviderServiceUseCase updateProviderServiceUseCase,
            GetProviderServiceUseCase getProviderServiceUseCase,
            GetProviderServicesUseCase getProviderServicesUseCase,
            DeleteProviderServiceUseCase deleteProviderServiceUseCase
            )
        {
            _createProviderServicesUseCase = createProviderServicesUseCase;
            _updateProviderServiceUseCase = updateProviderServiceUseCase;
            _getProviderServiceUseCase = getProviderServiceUseCase;
            _getProviderServicesUseCase = getProviderServicesUseCase;
            _deleteProviderServiceUseCase = deleteProviderServiceUseCase;
        }

        public async Task<ResponseProviderServiceDto> CreateProviderServiceAsync(DTOs.ProviderServices.PostProviderServiceDto dto)
        {
            var data = await _createProviderServicesUseCase.ExecuteAsync(dto);
            return ResponseProviderServiceDto.FromEntity(data);
        }

        public async Task<ResponseProviderServiceDto> UpdateProviderServiceAsync(Guid id, PutProviderServiceDto dto)
        {
            var data = await _updateProviderServiceUseCase.ExecuteAsync(id, dto);
            return ResponseProviderServiceDto.FromEntity(data);
        }

        public async Task<ResponseProviderServiceDto> GetProviderServiceAsync(Guid id)
        {
            var data = await _getProviderServiceUseCase.ExecuteAsync(id);
            return ResponseProviderServiceDto.FromEntity(data);
        }

        public async Task<List<ResponseProviderServiceDto>> GetProviderServicesAsync()
        {
            var data = await _getProviderServicesUseCase.ExecuteAsync();
            return ResponseProviderServiceDto.FromEntities(data);
        }

        public async Task<bool> DeleteProviderServiceAsync(Guid id)
        {
            return await _deleteProviderServiceUseCase.ExecuteAsync(id);
        }
    }
}
