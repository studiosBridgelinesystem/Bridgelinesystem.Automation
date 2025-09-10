namespace Bridgeline.Automation.Domain.entities
{
    public class AutomationExecutionLog : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid? ExecutionId { get; set; }
        public Guid? CompanyIntegrationId { get; set; }
        public int DurationInSeconds { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime CompletedAt { get; set; }
        public virtual List<CompanyIntegration> CompanyIntegration { get; set; }
    }
}
