using System.ComponentModel.DataAnnotations;

namespace Bridgeline.Automation.Application.DTOs.Statuses
{
    public class PostStatusDto
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
    }
}
