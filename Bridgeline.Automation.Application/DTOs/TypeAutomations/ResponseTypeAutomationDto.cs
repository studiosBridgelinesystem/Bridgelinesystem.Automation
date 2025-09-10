using Bridgeline.Automation.Domain.entities;

namespace Bridgeline.Automation.Application.DTOs.TypeAutomations
{
    public class ResponseTypeAutomationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string N8nTemplateId { get; set; }
        public Dictionary<string, string> DefaultConfig { get; set; }

        public ResponseTypeAutomationDto() { }

        public static ResponseTypeAutomationDto FromEntity(TypeAutomation entity)
        {
            if (entity == null) return null;
            return new ResponseTypeAutomationDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                N8nTemplateId = entity.N8nTemplateId,
                DefaultConfig = entity.DefaultConfig
            };
        }
    }
}
