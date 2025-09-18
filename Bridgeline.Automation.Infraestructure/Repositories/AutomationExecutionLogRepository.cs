
using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;
using Bridgeline.Automation.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Bridgeline.Automation.Infraestructure.Repositories
{
    public class AutomationExecutionLogRepository: IAutomationExecutionLogRepository
    {
        private readonly AutomationContext _context;

        public AutomationExecutionLogRepository(AutomationContext context)
        {
            _context = context;
        }
        public async Task<AutomationExecutionLog> Create (AutomationExecutionLog log)
        {
            _context.ExecutionLogs.Add(log);
            await _context.SaveChangesAsync();
            return log;
        }

        public async Task<AutomationExecutionLog> Update (AutomationExecutionLog log)
        {
            var data = _context.ExecutionLogs.Update(log);
            await _context.SaveChangesAsync();
            return log;
        }

        public async Task<List<AutomationExecutionLog>> GetAll ()
        {
            return await _context.ExecutionLogs 
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<AutomationExecutionLog> GetById (Guid id)
        {
            return await _context.ExecutionLogs 
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Delete (Guid id)
        {
            var log= await _context.ExecutionLogs.FirstOrDefaultAsync(a => a.Id == id && a.IsActive);
            if (log== null) return false;
            
            log.IsActive = false;
            log.UpdatedAt = DateTime.Now;

            _context.ExecutionLogs.Update(log);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
