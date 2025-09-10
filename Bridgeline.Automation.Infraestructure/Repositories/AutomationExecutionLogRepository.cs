
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
        public async Task<AutomationExecutionLog> PostAutomationExecutionLog(AutomationExecutionLog log)
        {
            _context.ExecutionLogs.Add(log);
            await _context.SaveChangesAsync();
            return log;
        }

        public async Task<AutomationExecutionLog> PutAutomationExecutionLog(AutomationExecutionLog log)
        {
            var data = _context.ExecutionLogs.Update(log);
            await _context.SaveChangesAsync();
            return log;
        }

        public async Task<List<AutomationExecutionLog>> GetAutomationExecutionLogs()
        {
            return await _context.ExecutionLogs 
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<AutomationExecutionLog> GetAutomationExecutionLog(Guid id)
        {
            return await _context.ExecutionLogs 
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> DeleteAutomationExecutionLog(Guid id)
        {
            var log= await _context.ExecutionLogs .FindAsync(id);
            if (log== null)
            {
                return false;
            }
            _context.ExecutionLogs .Remove(log);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
