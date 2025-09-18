using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.AutomationExecutionLogs
{
    public class GetAutomationExecuteLogUseCase
    {
        private readonly IAutomationExecutionLogRepository _automationExecutionLogRepository;
        public GetAutomationExecuteLogUseCase(IAutomationExecutionLogRepository automationExecutionLogRepository)
        {
            _automationExecutionLogRepository = automationExecutionLogRepository;
        }
        public async Task<AutomationExecutionLog> ExecuteAsync(Guid id)
        {
            return await _automationExecutionLogRepository.GetById(id);
        }
    }
}
