using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.CompanyIntegrations
{
    public class DeleteCompanyIntegrationUseCase
    {
        private readonly ICompanyIntegrationRepository _companyIntegrationRepository;
        public DeleteCompanyIntegrationUseCase(ICompanyIntegrationRepository companyIntegrationRepository)
        {
            _companyIntegrationRepository = companyIntegrationRepository;
        }
        public async Task<bool> ExecuteAsync(Guid id)
        {
            return await _companyIntegrationRepository.Delete(id);
        }
    }
}
