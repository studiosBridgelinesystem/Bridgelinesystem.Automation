using Bridgeline.Automation.Application.DTOs.ProviderServices;
using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.ProviderServices
{
    public class CreateProviderServicesUseCase
    {
        private readonly IProviderServiceRepository _providerServiceRepository;

        public async Task<ProviderService> ExecuteAsync(PostProviderServiceDto dto) {

            var existingName = await _providerServiceRepository.FindByName(dto.Name);
            
            if (existingName == null) {
                throw new InvalidOperationException($"The name {dto.Name} already exists.");
            }

            var NewproviderService = new ProviderService
            {
                Name = dto.Name,
                RequiredCredentials = dto.RequiredCredentials,
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            return await _providerServiceRepository.Create(NewproviderService);
        
        }
    }
}
