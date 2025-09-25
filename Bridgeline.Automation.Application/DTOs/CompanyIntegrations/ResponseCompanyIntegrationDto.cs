using Bridgeline.Automation.Domain.entities;

namespace Bridgeline.Automation.Application.DTOs.CompanyIntegrations
{
    public class ResponseCompanyIntegrationDto
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

        public ResponseCompanyIntegrationDto () { }

        public static ResponseCompanyIntegrationDto FromEntity(CompanyIntegration entity)
        {
            if (entity == null) return null;
            return new ResponseCompanyIntegrationDto
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

        public static List<ResponseCompanyIntegrationDto> FromEntities(IEnumerable<CompanyIntegration> entities) =>
            entities?.Select(FromEntity).ToList();
    }
}
