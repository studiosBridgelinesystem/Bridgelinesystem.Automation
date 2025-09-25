using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;
using Bridgeline.Automation.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Bridgeline.Automation.Infraestructure.Repositories
{
    public class ProviderRepository: IProviderRepository
    {

        private readonly AutomationContext _context;

        public ProviderRepository(AutomationContext context) { 
            _context = context;
        }

        public async Task<Provider> Create (Provider provider)
        {
            _context.Providers.Add(provider);
            await _context.SaveChangesAsync();
            return provider;
        }

        public async Task<Provider> Update (Provider provider)
        {
            _context.Providers.Update(provider);
            await _context.SaveChangesAsync();
            return provider;
        }

        public async Task<Provider> FindByName (string name)
        {
            return await _context.Providers.FirstOrDefaultAsync(x => x.Name == name && x.IsActive);
        }

        public async Task<IEnumerable<Provider>> GetAll ()
        {
            return await _context.Providers
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Provider> GetById (Guid id)
        {
            return await _context.Providers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
        }

        public async Task<bool> Delete (Guid id)
        {
            var provider = await _context.Providers.FirstOrDefaultAsync(p => p.IsActive && p.Id == id);

            if (provider == null)
            {
                return false;
            }
            _context.Providers.Remove(provider);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
