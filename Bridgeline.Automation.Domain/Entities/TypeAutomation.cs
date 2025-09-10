namespace Bridgeline.Automation.Domain.entities
{
    public class TypeAutomation: BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string N8nTemplateId { get; set; }
        public Dictionary<string, string> DefaultConfig { get; set; }
    }
}
