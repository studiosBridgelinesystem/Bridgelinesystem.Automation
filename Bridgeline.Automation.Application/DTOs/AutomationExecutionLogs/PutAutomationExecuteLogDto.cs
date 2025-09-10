namespace Bridgeline.Automation.Application.DTOs.AutomationExecutionLogs
{
    public class PutAutomationExecuteLogDto
    {
        public Guid ExecutionId { get; set; }
        public Guid CompanyIntegrationId { get; set; }
        public int DurationInSeconds { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime CompletedAt { get; set; }
    }
}
