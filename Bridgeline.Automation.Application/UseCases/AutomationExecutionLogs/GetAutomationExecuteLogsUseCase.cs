using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.AutomationExecutionLogs
{
    public class GetAutomationExecuteLogsUseCase
    {
        private readonly IAutomationExecutionLogRepository _automationExecutionLogRepository;
        public GetAutomationExecuteLogsUseCase( IAutomationExecutionLogRepository automationExecutionLogRepository)
        {
            _automationExecutionLogRepository = automationExecutionLogRepository;
        }
        public async Task<List<AutomationExecutionLog>> ExecuteAsync()
        {
            return await _automationExecutionLogRepository.GetAll();
        }
    }
}
