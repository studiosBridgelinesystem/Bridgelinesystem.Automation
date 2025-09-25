using Bridgeline.Automation.Domain.entities;

namespace Bridgeline.Automation.Application.DTOs.Statuses
{
    public class ResponseStatusDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ResponseStatusDto() { }

        public static ResponseStatusDto FromEntity(Status entity)
        {
            if (entity == null) return null;
            return new ResponseStatusDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static List<ResponseStatusDto> FromEntities(IEnumerable<Status> entities) =>
        entities?.Select(FromEntity).ToList();
    }
}
