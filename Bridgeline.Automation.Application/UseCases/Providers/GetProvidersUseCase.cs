using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;
namespace Bridgeline.Automation.Application.UseCases.Providers
{
    public class GetProvidersUseCase
    {
        private readonly IProviderRepository _providerRepository;
        public GetProvidersUseCase(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }
        public async Task<IEnumerable<Provider>> ExecuteAsync()
        {
            return await _providerRepository.GetAll();
        }
    }
}
