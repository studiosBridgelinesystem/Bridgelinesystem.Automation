
using Bridgeline.Automation.Domain.entities;

namespace Bridgeline.Automation.Domain.Interfaces.Repositories
{
    public interface ICompanyAutomationRepository
    {
        Task<CompanyAutomation> Create (CompanyAutomation companyAutomation);
        Task<CompanyAutomation> Update (CompanyAutomation companyAutomation);
        Task<CompanyAutomation> FindByName(string name);
        Task<List<CompanyAutomation>> GetAll();
        Task<CompanyAutomation> GetById(Guid id);
        Task<bool> Delete (Guid id);
    }
}
