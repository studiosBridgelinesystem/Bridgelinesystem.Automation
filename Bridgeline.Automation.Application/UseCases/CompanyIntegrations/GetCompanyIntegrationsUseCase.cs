using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.CompanyIntegrations
{
    public class GetCompanyIntegrationsUseCase
    {
        private readonly ICompanyIntegrationRepository _companyIntegrationRepository;
        public GetCompanyIntegrationsUseCase (ICompanyIntegrationRepository companyIntegrationRepository)
        {
            _companyIntegrationRepository = companyIntegrationRepository;
        }

        public async Task<IEnumerable<CompanyIntegration>> ExecuteAsync()
        {
            return await _companyIntegrationRepository.GetAll();
        }
    }
}
