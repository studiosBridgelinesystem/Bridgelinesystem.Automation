using Bridgeline.Automation.Domain.entities;

namespace Bridgeline.Automation.Application.DTOs.Providers
{
    public class ResponseProviderDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ResponseProviderDto() { }

        public static ResponseProviderDto FromEntity(Provider entity)
        {
            if (entity == null) return null;
            return new ResponseProviderDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static List<ResponseProviderDto> FromEntities(IEnumerable<Provider> entities) =>
            entities?.Select(FromEntity).ToList();
    }
}
