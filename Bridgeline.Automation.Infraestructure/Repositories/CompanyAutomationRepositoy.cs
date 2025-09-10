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

        public async Task<CompanyAutomation> PostCompanyAutomation(CompanyAutomation companyAutomation)
        {
            _context.CompanyAutomations.Add(companyAutomation);
            await _context.SaveChangesAsync();
            return companyAutomation;
        }

        public async Task<CompanyAutomation> PutCompanyAutomation(CompanyAutomation companyAutomation)
        {
            _context.CompanyAutomations.Update(companyAutomation);
            await _context.SaveChangesAsync();
            return companyAutomation;
        }

        public async Task<CompanyAutomation> FindByNameCompanyAutomation(string name)
        {
            return await _context.CompanyAutomations.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<CompanyAutomation>> GetCompanyAutomations()
        {
            return await _context.CompanyAutomations
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<CompanyAutomation> GetCompanyAutomation(Guid id)
        {
            return await _context.CompanyAutomations
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> DeleteCompanyAutomation(Guid id)
        {
            var companyAutomation = await _context.CompanyAutomations.FindAsync(id);
            if (companyAutomation == null)
            {
                return false;
            }
            _context.CompanyAutomations.Remove(companyAutomation);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
