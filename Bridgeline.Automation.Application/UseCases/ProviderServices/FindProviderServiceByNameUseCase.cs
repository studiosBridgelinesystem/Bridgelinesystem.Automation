
using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.ProviderServices
{
    public class FindProviderServiceByNameUseCase
    {
        private readonly IProviderServiceRepository _providerServiceRepository;

        public FindProviderServiceByNameUseCase (IProviderServiceRepository providerServiceRepository)
        {
            _providerServiceRepository = providerServiceRepository;
        }

        public async Task<ProviderService> ExecuteAsync(string name) {

            return await _providerServiceRepository.FindByName(name);
        }
                
    }
}
