

using System.ComponentModel.DataAnnotations;

namespace Bridgeline.Automation.Application.DTOs.ProviderServices
{
    public class PostProviderServiceDto
    {
        [Required(ErrorMessage = "The {0} field is required")]
        public Guid ProviderId { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        public bool? RequiredCredentials { get; set; }
    }
}
