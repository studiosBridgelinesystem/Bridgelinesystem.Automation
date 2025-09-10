
using System.ComponentModel.DataAnnotations;

namespace Bridgeline.Automation.Application.DTOs.CompanyIntegrations
{
    internal class PutCompanyIntegrationDto
    {

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Credentials { get; set; }
        public Dictionary<string, string> Configuration { get; set; }
        public Guid? ProviderServiceId { get; set; }
        public DateTime LastSyncAt { get; set; }
        public Guid? StatusId { get; set; }
    }
}
