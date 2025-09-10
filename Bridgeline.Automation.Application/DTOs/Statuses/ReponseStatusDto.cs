using Bridgeline.Automation.Domain.entities;

namespace Bridgeline.Automation.Application.DTOs.Statuses
{
    public class ReponseStatusDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ReponseStatusDto() { }
        public static ReponseStatusDto FromEntity(Status entity)
        {
            if (entity == null) return null;
            return new ReponseStatusDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
