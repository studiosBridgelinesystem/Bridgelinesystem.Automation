

using System.ComponentModel.DataAnnotations;

namespace Bridgeline.Automation.Application.DTOs.Providers
{
    public class PostProviderDto
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; } 
    }
}
