using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.CompanyIntegrations
{
    public class FindCompanyIntegrationByNameUseCase
    {
        private readonly ICompanyIntegrationRepository _companyIntegrationRepository;

        public FindCompanyIntegrationByNameUseCase(ICompanyIntegrationRepository companyIntegrationRepository)
        {
            _companyIntegrationRepository = companyIntegrationRepository;
        }

        public async Task<CompanyIntegration> ExecuteAsync (string name)
        {
            return await _companyIntegrationRepository.FindByName(name);
        }
    }
}
