using Bridgeline.Automation.Domain.entities;

namespace Bridgeline.Automation.Domain.Interfaces.Repositories
{
    public interface IAutomationExecutionLogRepository
    {
        Task<AutomationExecutionLog> Create(AutomationExecutionLog automationExecutionLog);
        Task<AutomationExecutionLog> Update (AutomationExecutionLog automationExecutionLog);
        Task<AutomationExecutionLog> GetById (Guid automationId);
        Task<List<AutomationExecutionLog>> GetAll();
        Task<bool> Delete (Guid id);
    }
}
