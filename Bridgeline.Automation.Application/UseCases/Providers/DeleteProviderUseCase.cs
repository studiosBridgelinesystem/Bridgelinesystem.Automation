using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.Providers
{
    public class DeleteProviderUseCase
    {
        private readonly IProviderRepository _providerRepository;

        public DeleteProviderUseCase(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public async Task<bool> ExecuteAsync(Guid id)
        {
            return await _providerRepository.Delete(id);
        }
    }
}
