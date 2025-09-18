using Bridgeline.Automation.Application.DTOs.ProviderServices;
using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.ProviderServices
{
    public class UpdateProviderServiceUseCase
    {
        private readonly IProviderServiceRepository _providerServiceRepository;
        public UpdateProviderServiceUseCase(IProviderServiceRepository providerServiceRepository)
        {
            _providerServiceRepository = providerServiceRepository;
        }
        public async Task<ProviderService> ExecuteAsync (Guid id,PutProviderServiceDto providerService)
        {
            var existingProviderService = await _providerServiceRepository.GetById(id) ?? throw new Exception("Provider Service not found.");
            var existingName = await _providerServiceRepository.FindByName(providerService.Name);
            if (existingName != null && existingName.Id != id)
            {
                throw new Exception("A Provider Service with the same name already exists.");
            }

            existingProviderService.Name = providerService.Name ?? existingProviderService.Name;
            existingProviderService.RequiredCredentials = providerService.RequiredCredentials ?? existingProviderService.RequiredCredentials;
            existingProviderService.IsActive = existingProviderService.IsActive;
            existingProviderService.UpdatedAt = DateTime.UtcNow;

            return await _providerServiceRepository.Update(existingProviderService);
        }
    }
}
