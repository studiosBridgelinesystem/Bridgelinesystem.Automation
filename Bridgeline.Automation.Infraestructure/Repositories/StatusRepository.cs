using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;
using Bridgeline.Automation.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Bridgeline.Automation.Infraestructure.Repositories
{
    public class StatusRepository: IStatusRepository
    {
        private readonly AutomationContext _context;

        public StatusRepository(AutomationContext context)
        {
            _context = context;
        }

        public async Task<Status> Create (Status Status)
        {
            _context.Statuses.Add(Status);
            await _context.SaveChangesAsync();
            return Status;
        }

        public async Task<Status> Update(Status Status)
        {
            {
               _context.Statuses.Update(Status);
                await _context.SaveChangesAsync();
                return Status;
            }
        }

        public async Task<Status> FindByName (string name)
        {
            return await _context.Statuses.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<Status>> GetAll()
        {
            return await _context.Statuses
                .Where(s => s.IsActive)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Status> GetById (Guid id)
        {
            return await _context.Statuses
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id && s.IsActive);
        }

        public async Task<bool> Delete (Guid id)
        {
            var status = await _context.Statuses.FirstOrDefaultAsync(s => s.Id == id && s.IsActive);

            if (status == null)
            {
                return false;
            }

            status.IsActive = false;

            _context.Statuses.Update(status);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
