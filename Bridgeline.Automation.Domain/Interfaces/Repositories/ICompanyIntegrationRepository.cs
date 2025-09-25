using Bridgeline.Automation.Domain.entities;

namespace Bridgeline.Automation.Domain.Interfaces.Repositories
{
    public interface ICompanyIntegrationRepository
    {
        Task<CompanyIntegration> Create (CompanyIntegration companyIntegration);
        Task<CompanyIntegration> Update(CompanyIntegration companyIntegration);
        Task<CompanyIntegration> FindByName(string name);
        Task<List<CompanyIntegration>> GetAll();
        Task<CompanyIntegration> GetById(Guid id);
        Task<bool> Delete(Guid id);
    }
}
