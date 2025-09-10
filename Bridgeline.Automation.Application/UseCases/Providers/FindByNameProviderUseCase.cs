

using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.Providers
{
    public class FindByNameProviderUseCase
    {
        private readonly IProviderRepository _providerRepository;
        public FindByNameProviderUseCase(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public async Task<Provider> ExecuteAsync(string name)
        {
            return await _providerRepository.FindByName(name);
        }
    }
}
