using Bridgeline.Automation.Domain.entities;

namespace Bridgeline.Automation.Application.DTOs.ProviderServices
{
    public class ResponseProviderServiceDto
    {
        public Guid Id { get; set; }
        public Guid ProviderId { get; set; }
        public string Name { get; set; }
        public bool RequiredCredentials { get; set; }
        public virtual Provider Provider { get; set; }
        public ResponseProviderServiceDto() { }
        public static ResponseProviderServiceDto EntityToDto(ProviderService entity)
        {
            if (entity == null) return null;
            return new ResponseProviderServiceDto
            {
                Id = entity.Id,
                ProviderId = entity.ProviderId ?? new Guid(),
                Name = entity.Name,
                RequiredCredentials = entity.RequiredCredentials,
                Provider = entity.Provider
            };
        }
    }
}
