using Bridgeline.Automation.Application.DTOs.Providers;
using Bridgeline.Automation.Application.Exceptions;
using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.Providers
{
    public class CreateProviderUseCase
    {
        private readonly IProviderRepository _providerRepository;
        private readonly FindByNameProviderUseCase _findByNameProviderUseCase;

        public CreateProviderUseCase(IProviderRepository providerRepository, FindByNameProviderUseCase findByNameProviderUseCase)
        {
            _providerRepository = providerRepository;
            _findByNameProviderUseCase = findByNameProviderUseCase;
        }

        public async Task<Provider> ExecuteAsync(PostProviderDto dto)
        {
            var existingProvider = await _findByNameProviderUseCase.ExecuteAsync(dto.Name);

            if(existingProvider !=null)
            {
                throw new ConflictException("Provider with the same name already exists.");
            }
            var provider = new Provider
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };
            return await _providerRepository.Create(provider);

        }

    }
}
