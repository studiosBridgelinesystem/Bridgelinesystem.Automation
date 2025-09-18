using Bridgeline.Automation.Domain.entities;

namespace Bridgeline.Automation.Domain.Interfaces.Repositories
{
    public interface ITypeAutomationRepository
    {
        Task<TypeAutomation> Create (TypeAutomation entity);
        Task<TypeAutomation> Update(TypeAutomation entity);
        Task<TypeAutomation> FindByName (string name);
        Task <List<TypeAutomation>> GetAll ();
        Task<TypeAutomation> GetById (Guid id);
        Task<bool> Delete (Guid id);
    }
}
