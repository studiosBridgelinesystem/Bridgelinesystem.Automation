using Bridgeline.Automation.Application.DTOs.ProviderServices;


namespace Bridgeline.Automation.Application.Interfaces.Services
{
    public interface IProviderServicesService
    {
        Task<ResponseProviderServiceDto> CreateProviderServiceAsync(PostProviderServiceDto dto);

        Task<ResponseProviderServiceDto> UpdateProviderServiceAsync(Guid id, PutProviderServiceDto dto);

        Task<ResponseProviderServiceDto> GetProviderServiceAsync(Guid id);

        Task<List<ResponseProviderServiceDto>> GetProviderServicesAsync();

        Task<bool> DeleteProviderServiceAsync(Guid id);
    }
}
