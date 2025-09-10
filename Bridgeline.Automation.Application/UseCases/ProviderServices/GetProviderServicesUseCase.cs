using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.ProviderServices
{
    public class GetProviderServicesUseCase
    {
        private readonly IProviderServiceRepository _providerServiceRepository;

        public GetProviderServicesUseCase (IProviderServiceRepository providerServiceRepository)
        {
            _providerServiceRepository = providerServiceRepository;
        }
        
        public async Task<IEnumerable<ProviderService>> ExecuteAsync()
        {
            return await _providerServiceRepository.GetAll();
        } 
    }
}
