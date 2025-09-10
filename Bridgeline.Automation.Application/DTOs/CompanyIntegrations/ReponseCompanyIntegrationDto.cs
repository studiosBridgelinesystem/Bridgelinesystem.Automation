using Bridgeline.Automation.Domain.entities;
using System.Net.NetworkInformation;


namespace Bridgeline.Automation.Application.DTOs.CompanyIntegrations
{
    public class ReponseCompanyIntegrationDto
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

        public ReponseCompanyIntegrationDto () { }

        public static ReponseCompanyIntegrationDto FromEntity(CompanyIntegration entity)
        {
            if (entity == null) return null;
            return new ReponseCompanyIntegrationDto
            {
                Id = entity.Id,
                TenantId = entity.TenantId,
                Name = entity.Name,
                Credentials = entity.Credentials,
                Configuration = entity.Configuration,
                ProviderServiceId = entity.ProviderServiceId,
                LastSyncAt = entity.LastSyncAt,
                StatusId = entity.StatusId,
                ProviderService = entity.ProviderService,
                Status = entity.Status
            };
        }
    }
}
