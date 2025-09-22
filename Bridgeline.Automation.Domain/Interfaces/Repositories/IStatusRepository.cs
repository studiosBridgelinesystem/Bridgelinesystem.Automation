using Bridgeline.Automation.Domain.entities;

namespace Bridgeline.Automation.Domain.Interfaces.Repositories
{
    public interface IStatusRepository
    {
        Task<Status> Create ( Status status);
        Task <Status> Update ( Status status);
        Task<Status> FindByName(string name);
        Task<List<Status>> GetAll ();
        Task<Status> GetById (Guid id);
        Task<bool> Delete (Guid id);
    }
}
