using Bridgeline.Automation.Domain.entities;

namespace Bridgeline.Automation.Domain.Interfaces.Repositories
{
    public interface IAutomationExecutionLogRepository
    {
        Task<AutomationExecutionLog> PostAutomationExecutionLog(AutomationExecutionLog automationExecutionLog);
        Task<AutomationExecutionLog> PutAutomationExecutionLog(AutomationExecutionLog automationExecutionLog);
        Task<AutomationExecutionLog> GetAutomationExecutionLog(Guid automationId);
        Task<List<AutomationExecutionLog>> GetAutomationExecutionLogs();
        Task<bool> DeleteAutomationExecutionLog(Guid id);
    }
}
