using Bridgeline.Automation.Domain.entities;

namespace Bridgeline.Automation.Application.DTOs.AutomationExecutionLogs
{
    public class ResponseAutomationExecuteLogDto
    {
        public Guid Id { get; set; }
        public Guid ExecutionId { get; set; }
        public Guid CompanyIntegrationId { get; set; }
        public int DurationInSeconds { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime CompletedAt { get; set; }
        public virtual List<CompanyIntegration> CompanyIntegration { get; set; }
        public ResponseAutomationExecuteLogDto() { }

        public static ResponseAutomationExecuteLogDto FromEntity (AutomationExecutionLog log)
        {
            if (log == null) return null;
            var dto = new ResponseAutomationExecuteLogDto
            {
                Id = log.Id,
                ExecutionId = log.ExecutionId ?? new Guid(),
                CompanyIntegrationId = log.CompanyIntegrationId ?? new Guid(),
                DurationInSeconds = log.DurationInSeconds,
                StartedAt = log.StartedAt,
                CompletedAt = log.CompletedAt,
                CompanyIntegration = log.CompanyIntegration
            };
            return dto;
        }

        public static List<ResponseAutomationExecuteLogDto> FromEntities(IEnumerable<AutomationExecutionLog> logs) =>
            logs?.Select(FromEntity).ToList();
    }

}
