namespace Bridgeline.Automation.Domain.entities
{
    public class CompanyIntegration : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid? TenantId { get; set; }
        public string Name { get; set; }
        public string Credentials { get; set; }
        public Dictionary<string, string> Configuration { get; set; }
        public Guid? ProviderServiceId { get; set; }
        public DateTime? LastSyncAt { get; set; } 
        public Guid? StatusId { get; set; }
        public virtual ProviderService ProviderService { get; set; }
        public virtual Status Status { get; set; }
    }
}
