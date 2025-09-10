
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.ProviderServices
{
    public class DeleteProviderServiceUseCase
    {
        private readonly IProviderServiceRepository _providerServiceRepository;

        public DeleteProviderServiceUseCase(IProviderServiceRepository providerServiceRepository)
        {
            _providerServiceRepository = providerServiceRepository;
        }

        public async Task<bool> ExecuteAsync (Guid id)
        {
            return await _providerServiceRepository.Delete(id);
        }
    }
}
