using System.ComponentModel.DataAnnotations;

namespace Bridgeline.Automation.Application.DTOs.ProviderServices
{
    public class PutProviderServiceDto
    {
        [StringLength(50)]
        public string Name { get; set; }
        public bool? RequiredCredentials { get; set; }
    }
}
