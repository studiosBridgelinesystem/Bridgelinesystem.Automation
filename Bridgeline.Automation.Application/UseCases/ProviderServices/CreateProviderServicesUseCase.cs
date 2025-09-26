using Bridgeline.Automation.Application.DTOs.ProviderServices;
using Bridgeline.Automation.Application.Exceptions;
using Bridgeline.Automation.Application.UseCases.Providers;
using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.ProviderServices
{
    public class CreateProviderServicesUseCase
    {
        private readonly IProviderServiceRepository _providerServiceRepository;
        private readonly GetProviderUseCase _getProviderUseCase;

        public CreateProviderServicesUseCase(
            IProviderServiceRepository providerServiceRepository, 
            GetProviderUseCase getProviderUseCase)
        {
            _providerServiceRepository = providerServiceRepository;
            _getProviderUseCase = getProviderUseCase;
        }
        public async Task<ProviderService> ExecuteAsync(PostProviderServiceDto dto) {


            _ = await _getProviderUseCase.ExecuteAsync(dto.ProviderId) ?? throw new NotFoundException($"Provider with id {dto.ProviderId} not found.");
             
           
            var existing = await _providerServiceRepository.FindByName(dto.Name);
            if (existing != null)
            {
                throw new ConflictException($"The name {dto.Name} already exists.");
            }


            var NewProviderService = new ProviderService
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                ProviderId = dto.ProviderId,
                RequiredCredentials = (bool)dto.RequiredCredentials,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            return await _providerServiceRepository.Create(NewProviderService);
        
        }
    }
}
