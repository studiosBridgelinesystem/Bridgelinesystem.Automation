
using Bridgeline.Automation.Domain.entities;

namespace Bridgeline.Automation.Domain.Interfaces.Repositories
{
    public interface ICompanyAutomationRepository
    {
        Task<CompanyAutomation> PostCompanyAutomation(CompanyAutomation companyAutomation);
        Task<CompanyAutomation> PutCompanyAutomation(CompanyAutomation companyAutomation);
        Task<CompanyAutomation> FindByNameCompanyAutomation(string name);
        Task<List<CompanyAutomation>> GetCompanyAutomations();
        Task<CompanyAutomation> GetCompanyAutomation(Guid id);
        Task<bool> DeleteCompanyAutomation(Guid id);
    }
}
