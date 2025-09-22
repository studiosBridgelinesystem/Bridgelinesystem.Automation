using Bridgeline.Automation.Application.DTOs.Statuses;

namespace Bridgeline.Automation.Application.Interfaces.Services
{
    public interface IStatusServices
    {
        public Task<ResponseStatusDto> CreateStatusService(PostStatusDto status);
        public Task<ResponseStatusDto> UpdateStatusService(Guid id, PutStatusDto status);
        public Task<ResponseStatusDto> FindByNameStatusService(string name);
        public Task<ResponseStatusDto> GetStatusService(Guid id);
        public Task<List<ResponseStatusDto>> GetStatusesService();
        public Task<bool> DeleteStatusService(Guid statusId);

    }
}
