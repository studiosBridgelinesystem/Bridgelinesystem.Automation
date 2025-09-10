
namespace Bridgeline.Automation.Domain.entities
{
    public class CompanyAutomation : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid? TenantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? TypeAutomationId { get; set; }
        public string N8nWorkflowId { get; set; }
        public int RunFrequency { get; set; }
        public Dictionary<string, string> Conditions { get; set; }
        public Dictionary<string, string> Tiggers { get; set; }
        public Dictionary<string, string> Configuration { get; set; }
        public virtual TypeAutomation TypeAutomation { get; set; }
    }
}
