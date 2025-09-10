using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.ProviderServices
{
    public class GetProviderServiceUseCase
    {
        private readonly IProviderServiceRepository _providerServiceRepository;

        public GetProviderServiceUseCase(IProviderServiceRepository providerServiceRepository)
        {
            _providerServiceRepository = providerServiceRepository;
        }

        public async Task<ProviderService> ExecuteAsync(Guid id)
        {
            return await _providerServiceRepository.GetById(id);
        } 
    }
}
