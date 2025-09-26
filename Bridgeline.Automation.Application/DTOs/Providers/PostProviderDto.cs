

using System.ComponentModel.DataAnnotations;

namespace Bridgeline.Automation.Application.DTOs.Providers
{
    public class PostProviderDto
    {
        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(30)]
        public string Name { get; set; } 
    }
}
