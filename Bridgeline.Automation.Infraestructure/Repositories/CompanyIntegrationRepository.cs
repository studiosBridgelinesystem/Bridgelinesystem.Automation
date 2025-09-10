using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;
using Bridgeline.Automation.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Bridgeline.Automation.Infraestructure.Repositories
{
    public class CompanyIntegrationRepository : ICompanyIntegrationRepository
    {
        private readonly AutomationContext _context;
        public CompanyIntegrationRepository(AutomationContext context)
        {
            _context = context;
        }

        public async Task<CompanyIntegration> Create (CompanyIntegration companyIntegration)
        {
            _context.CompanyIntegrations.Add(companyIntegration);
            await _context.SaveChangesAsync();
            return companyIntegration;
        }

        public async Task<CompanyIntegration> Update (Guid id ,CompanyIntegration companyIntegration)
        {
            var ExistingCompanyIntegration = await _context.CompanyIntegrations.FirstOrDefaultAsync(c => c.Id == id && c.IsActive);

            if (ExistingCompanyIntegration != null) {
            
            ExistingCompanyIntegration.Id = id;
            ExistingCompanyIntegration.Name = companyIntegration.Name ?? ExistingCompanyIntegration.Name;    
            ExistingCompanyIntegration.ProviderService = companyIntegration.ProviderService ?? ExistingCompanyIntegration.ProviderService;
            ExistingCompanyIntegration.ProviderServiceId = companyIntegration.ProviderServiceId ?? ExistingCompanyIntegration.ProviderServiceId;
            ExistingCompanyIntegration.Configuration = companyIntegration.Configuration ?? ExistingCompanyIntegration.Configuration;
            ExistingCompanyIntegration.Credentials = companyIntegration.Credentials ?? ExistingCompanyIntegration.Credentials;
            ExistingCompanyIntegration.StatusId = companyIntegration.StatusId ?? ExistingCompanyIntegration.StatusId;
            ExistingCompanyIntegration.LastSyncAt = companyIntegration.LastSyncAt ?? ExistingCompanyIntegration.LastSyncAt;
            ExistingCompanyIntegration.TenantId = companyIntegration.TenantId ?? ExistingCompanyIntegration.TenantId;
            ExistingCompanyIntegration.UpdatedAt = DateTime.Now;
            }
            var data = _context.CompanyIntegrations.Update(ExistingCompanyIntegration);
            await _context.SaveChangesAsync();
            return companyIntegration;
        }

        public async Task<CompanyIntegration> FindByName(string name)
        {
            return await _context.CompanyIntegrations.FirstOrDefaultAsync(c => c.Name == name && c.IsActive);
        }

        public async Task<List<CompanyIntegration>> GetAll ()
        {
            return await _context.CompanyIntegrations
                .Where(c => c.IsActive)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<CompanyIntegration> GetById (Guid id)
        {
            return await _context.CompanyIntegrations
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Delete(Guid id)
        {
            var companyIntegration = await _context.CompanyIntegrations.FirstOrDefaultAsync(c => c.IsActive && c.Id == id);
            if (companyIntegration == null)
            {
                return false;
            }

            companyIntegration.IsActive = false;

            _context.CompanyIntegrations.Update(companyIntegration);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
