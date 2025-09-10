
using Bridgeline.Automation.Domain.entities;

namespace Bridgeline.Automation.Domain.Interfaces.Repositories
{
    public interface IProviderRepository
    {
        Task<Provider> Create(Provider provider);
        Task<Provider> Update(Guid id, Provider provider);
        Task<Provider> FindByName(string name);
        Task<IEnumerable<Provider>> GetAll();
        Task<Provider> GetById(Guid id);
        Task<bool> Delete(Guid id);
    }
}
