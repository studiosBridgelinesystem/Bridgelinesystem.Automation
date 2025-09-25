using Bridgeline.Automation.Application.DTOs.Providers;
using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.Providers
{
    public class UpdateProviderUseCase
    {
        private readonly IProviderRepository _providerRepository;
        private readonly FindByNameProviderUseCase _findByNameProviderUseCase;
        private readonly GetProviderUseCase _getProviderUseCase;

        public UpdateProviderUseCase(IProviderRepository providerRepository, FindByNameProviderUseCase findByNameProviderUseCase, GetProviderUseCase getProviderUseCase)
        {
            _providerRepository = providerRepository;
            _findByNameProviderUseCase = findByNameProviderUseCase;
            _getProviderUseCase = getProviderUseCase;
        }

        public async Task<Provider> ExecuteAsync (Guid Id, PutProviderDto dto)
        {
            var existingProvider = await _getProviderUseCase.ExecuteAsync(Id);

            if (existingProvider == null)
            {
                throw new ArgumentException("Provider not found.");
            }

            if(!string.IsNullOrEmpty(dto.Name) && dto.Name != existingProvider.Name)
            {
                var providerWithSameName = await _findByNameProviderUseCase.ExecuteAsync(dto.Name);

                if (providerWithSameName != null && providerWithSameName.Id != Id)
                {
                    throw new InvalidOperationException("Another provider with the same name already exists.");
                }


                existingProvider.Name = dto.Name;
                existingProvider.UpdatedAt = DateTime.Now;
            }

            return await _providerRepository.Update(existingProvider);
        }
    }
}
