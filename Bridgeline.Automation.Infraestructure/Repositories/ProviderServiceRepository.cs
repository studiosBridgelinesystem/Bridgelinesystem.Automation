using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;
using Bridgeline.Automation.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Bridgeline.Automation.Infraestructure.Repositories
{
    public class ProviderServiceRepository: IProviderServiceRepository
    {
        private readonly AutomationContext _context;

        public ProviderServiceRepository(AutomationContext context) { 
            _context = context;
        }

        public async Task<ProviderService> Create(ProviderService providerService)
        {
            _context.ProviderServices.Add(providerService);
            await _context.SaveChangesAsync();
            return providerService;
        }

        public async Task<ProviderService> Update(ProviderService providerService)
        {
            _context.ProviderServices.Update(providerService);
            await _context.SaveChangesAsync();
            return providerService;
        }

        public async Task<ProviderService> FindByName(string name)
        {
            return await _context.ProviderServices.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<ProviderService>> GetAll()
        {
            return await _context.ProviderServices
                .Where(x => x.IsActive)
                .Include(p => p.Provider)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ProviderService> GetById(Guid id)
        {
            return await _context.ProviderServices
                .Include(p => p.Provider)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
                
        }

        public async Task<bool> Delete(Guid id)
        {
            var providerService = await _context.ProviderServices.FirstOrDefaultAsync(p => p.IsActive && p.Id == id);
            if (providerService == null)
            {
                return false;
            }

            providerService.IsActive = false;
            _context.ProviderServices.Update(providerService);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
