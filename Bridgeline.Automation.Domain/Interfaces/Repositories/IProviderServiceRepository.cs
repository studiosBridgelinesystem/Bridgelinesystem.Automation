using Bridgeline.Automation.Domain.entities;

namespace Bridgeline.Automation.Domain.Interfaces.Repositories
{
    public interface IProviderServiceRepository
    {
        Task<ProviderService> Create (ProviderService providerService);
        Task<ProviderService> Update (ProviderService providerService);
        Task<ProviderService> FindByName (string name);
        Task <IEnumerable<ProviderService>> GetAll ();
        Task<ProviderService> GetById (Guid id);
        Task<bool> Delete (Guid id);
    }
}
