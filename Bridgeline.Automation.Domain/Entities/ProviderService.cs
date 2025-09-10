namespace Bridgeline.Automation.Domain.entities
{
    public class ProviderService : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid? ProviderId { get; set; }
        public string Name { get; set; }
        public bool RequiredCredentials { get; set; }
        public virtual Provider Provider { get; set; } 
    }
}
