using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;
using Bridgeline.Automation.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Bridgeline.Automation.Infraestructure.Repositories
{
    public class StatusRepository: IStatusRepository
    {
        private readonly AutomationContext _context;

        public StatusRepository(AutomationContext context)
        {
            _context = context;
        }

        public async Task<Status> PostStatus(Status Status)
        {
            _context.Statuses.Add(Status);
            await _context.SaveChangesAsync();
            return Status;
        }

        public async Task<Status> PutStatus(Status Status)
        {
            var data = _context.Statuses.Update(Status);
            await _context.SaveChangesAsync();
            return Status;
        }

        public async Task<Status> FindByNameStatus(string name)
        {
            return await _context.Statuses.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<Status>> GetStatuses()
        {
            return await _context.Statuses
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Status> GetStatus(Guid id)
        {
            return await _context.Statuses
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> DeleteStatus(Guid id)
        {
            var Status = await _context.Statuses.FindAsync(id);
            if (Status == null)
            {
                return false;
            }
            _context.Statuses.Remove(Status);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
