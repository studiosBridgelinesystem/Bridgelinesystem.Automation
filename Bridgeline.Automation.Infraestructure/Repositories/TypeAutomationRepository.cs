using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;
using Bridgeline.Automation.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Bridgeline.Automation.Infraestructure.Repositories
{
    public class TypeAutomationRepository : ITypeAutomationRepository
    {
        private readonly AutomationContext _context;
        public TypeAutomationRepository(AutomationContext context)
        {
            _context = context;
        }

        public async Task<TypeAutomation> Create (TypeAutomation typeAutomation)
        {
            _context.TypeAutomations.Add(typeAutomation);
            await _context.SaveChangesAsync();
            return typeAutomation;
        }

        public async Task<TypeAutomation> Update (TypeAutomation typeAutomation)
        {
            var data = _context.TypeAutomations.Update(typeAutomation);
            await _context.SaveChangesAsync();
            return typeAutomation;
        }

        public async Task<TypeAutomation> FindByName(string name)
        {
            return await _context.TypeAutomations.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<TypeAutomation>> GetAll()
        {
            return await _context.TypeAutomations
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TypeAutomation> GetById (Guid id)
        {
            return await _context.TypeAutomations
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Delete (Guid id)
        {
            var typeAutomation = await _context.TypeAutomations.FindAsync(id);
            if (typeAutomation == null)
            {
                return false;
            }
            _context.TypeAutomations.Remove(typeAutomation);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
