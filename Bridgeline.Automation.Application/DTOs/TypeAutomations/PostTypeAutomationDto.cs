
using System.ComponentModel.DataAnnotations;

namespace Bridgeline.Automation.Application.DTOs.TypeAutomations
{
    internal class PostTypeAutomationDto
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; } = string.Empty;
        public string N8nTemplateId { get; set; }
        public Dictionary<string, string> DefaultConfig { get; set; }
    }
}
