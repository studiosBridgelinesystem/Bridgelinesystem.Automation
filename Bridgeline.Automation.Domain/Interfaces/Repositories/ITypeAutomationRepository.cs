using Bridgeline.Automation.Domain.entities;

namespace Bridgeline.Automation.Domain.Interfaces.Repositories
{
    public interface ITypeAutomationRepository
    {
        Task<TypeAutomation> PostTypeAutomation (TypeAutomation typeAutomation);
        Task<TypeAutomation> PutTypeAutomation (TypeAutomation typeAutomation);
        Task<TypeAutomation> FindByNameTypeAutomation (string name);
        Task <List<TypeAutomation>> GetTypeAutomations ();
        Task<TypeAutomation> GetTypeAutomation (Guid id);
        Task<bool> DeleteTypeAutomation (Guid id);
    }
}
