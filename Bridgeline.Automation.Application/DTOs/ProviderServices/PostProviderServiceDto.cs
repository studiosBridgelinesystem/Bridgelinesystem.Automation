
using System.ComponentModel.DataAnnotations;

namespace Bridgeline.Automation.Application.DTOs.ProviderServices
{
    public class PostProviderServiceDto
    {
        [Required]
        public Guid? ProviderId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public bool RequiredCredentials { get; set; }
    }
}
