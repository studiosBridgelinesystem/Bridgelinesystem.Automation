using Bridgeline.Automation.Application.DTOs.Providers;

namespace Bridgeline.Automation.Application.Interfaces.Services
{
    public interface IProviderService
    {
        Task<ResponseProviderDto> CreateProviderAsync(PostProviderDto dto);

        Task<ResponseProviderDto> UpdateProviderAsync(Guid id, PutProviderDto dto);

        Task<ResponseProviderDto> GetProviderAsync(Guid id);

        Task<List<ResponseProviderDto>> GetProvidersAsync();

        Task<bool> DeleteProviderAsync(Guid id);
    }
}
