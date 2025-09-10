using Bridgeline.Automation.Domain.entities;
using System.ComponentModel.DataAnnotations;

namespace Bridgeline.Automation.Application.DTOs.CompanyAutomations
{
    internal class PutCompanyAutomationDto
    {

        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;

        [Required]
        public Guid TypeAutomationId { get; set; }
        public string N8nWorkflowId { get; set; }
        public int RunFrequency { get; set; }
        public Dictionary<string, string> Conditions { get; set; }
        public Dictionary<string, string> Tiggers { get; set; }
        public Dictionary<string, string> Configuration { get; set; }
    }
}
