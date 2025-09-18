using Bridgeline.Automation.Application.DTOs.AutomationExecutionLogs;
using Bridgeline.Automation.Application.UseCases.CompanyIntegrations;
using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.AutomationExecutionLogs
{
    public class CreateAutomationExecuteUseCase
    {
        private readonly IAutomationExecutionLogRepository _automationExecutionLogRepository;
        private readonly GetCompanyIntegrationUseCase _getCompanyIntegrationUseCase;
        public CreateAutomationExecuteUseCase(IAutomationExecutionLogRepository automationExecutionLogRepository, GetCompanyIntegrationUseCase getCompanyIntegrationUseCase)
        {
            _automationExecutionLogRepository = automationExecutionLogRepository;
            _getCompanyIntegrationUseCase = getCompanyIntegrationUseCase;
        }
        public async Task<AutomationExecutionLog> ExecuteAsync(PostAutomationExecuteLogDto automationExecutionLog)
        {


            if(automationExecutionLog.CompanyIntegrationId == Guid.Empty)
            {
                throw new Exception("Company Integration ID is required.");
            }



            var existingCompanyIntegrationId = await _getCompanyIntegrationUseCase.ExecuteAsync(automationExecutionLog.CompanyIntegrationId) ?? throw new Exception("Company Integration not found.");

            var newLog = new AutomationExecutionLog
            {
                Id = Guid.NewGuid(),
                ExecutionId = Guid.NewGuid(),
                CompanyIntegrationId = existingCompanyIntegrationId.Id,
                DurationInSeconds = automationExecutionLog.DurationInSeconds,
                StartedAt = automationExecutionLog.StartedAt,
                CompletedAt = automationExecutionLog.CompletedAt,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            return await _automationExecutionLogRepository.Create(newLog);
        }
    }
}
