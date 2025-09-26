using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.Providers
{
    public class GetProviderUseCase
    {
        private readonly IProviderRepository _providerRepository;

        public GetProviderUseCase(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public async Task<Provider> ExecuteAsync(Guid Id) {
        return await _providerRepository.GetById(Id);
        }
    }
}
