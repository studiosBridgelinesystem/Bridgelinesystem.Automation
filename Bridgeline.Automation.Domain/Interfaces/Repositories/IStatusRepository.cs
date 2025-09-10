using Bridgeline.Automation.Domain.entities;

namespace Bridgeline.Automation.Domain.Interfaces.Repositories
{
    public interface IStatusRepository
    {
        Task<Status> PostStatus ( Status status);
        Task <Status> PutStatus ( Status status);
        Task<Status> FindByNameStatus(string name);
        Task<List<Status>> GetStatuses ();
        Task<Status> GetStatus (Guid id);
        Task<bool> DeleteStatus (Guid id);
    }
}
