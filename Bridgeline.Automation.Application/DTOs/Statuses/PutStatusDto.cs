
using System.ComponentModel.DataAnnotations;

namespace Bridgeline.Automation.Application.DTOs.Statuses
{
    public class PutStatusDto
    {
        [StringLength(30)]
        public string Name { get; set; }
    }
}
