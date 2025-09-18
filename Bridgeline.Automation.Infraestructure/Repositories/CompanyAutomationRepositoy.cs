using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;
using Bridgeline.Automation.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Bridgeline.Automation.Infraestructure.Repositories
{
    public class CompanyAutomationRepositoy: ICompanyAutomationRepository
    {
        private readonly AutomationContext _context;

        public CompanyAutomationRepositoy(AutomationContext context)
        {
            _context = context;
        }

        public async Task<CompanyAutomation> Create (CompanyAutomation companyAutomation)
        {
            _context.CompanyAutomations.Add(companyAutomation);
            await _context.SaveChangesAsync();
            return companyAutomation;
        }

        public async Task<CompanyAutomation> Update (CompanyAutomation companyAutomation)
        {
            _context.CompanyAutomations.Update(companyAutomation);
            await _context.SaveChangesAsync();
            return companyAutomation;
        }

        public async Task<CompanyAutomation> FindByName (string name)
        {
            return await _context.CompanyAutomations.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<CompanyAutomation>> GetAll()
        {
            return await _context.CompanyAutomations
                .Where(c => c.IsActive)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<CompanyAutomation> GetById (Guid id)
        {
            return await _context.CompanyAutomations
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id && c.IsActive);
        }

        public async Task<bool> Delete (Guid id)
        {
            var companyAutomation = await _context.CompanyAutomations.FirstOrDefaultAsync(c => c.Id == id && c.IsActive);
            if (companyAutomation == null)
            {
                return false;
            }
            companyAutomation.IsActive = false;
            companyAutomation.UpdatedAt = DateTime.Now;

            _context.CompanyAutomations.Update(companyAutomation);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
