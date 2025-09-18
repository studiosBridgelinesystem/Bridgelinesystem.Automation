
using System.ComponentModel.DataAnnotations;

namespace Bridgeline.Automation.Application.DTOs.CompanyIntegrations
{
    public class PutCompanyIntegrationDto
    {

        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(150)]
        public string Credentials { get; set; }
        public Dictionary<string, string> Configuration { get; set; }
        public Guid? ProviderServiceId { get; set; }
        public DateTime? LastSyncAt { get; set; }
        public Guid? StatusId { get; set; }
    }
}
