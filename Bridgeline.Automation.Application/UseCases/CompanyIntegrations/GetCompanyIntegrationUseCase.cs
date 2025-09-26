

using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;


namespace Bridgeline.Automation.Application.UseCases.CompanyIntegrations
{
    public class GetCompanyIntegrationUseCase
    {
        private readonly ICompanyIntegrationRepository _companyIntegrationRepository;
        public GetCompanyIntegrationUseCase (ICompanyIntegrationRepository companyIntegrationRepository)
        {
            _companyIntegrationRepository = companyIntegrationRepository;
        }

        public async Task<CompanyIntegration> ExecuteAsync(Guid id)
        {
            return await _companyIntegrationRepository.GetById(id);
        }
    }
}
