using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;


namespace Bridgeline.Automation.Application.UseCases.CompanyAutomations
{
    public class GetCompanyAutomationsUseCase
    {
        private readonly ICompanyAutomationRepository _companyAutomationRepository;
        public GetCompanyAutomationsUseCase(ICompanyAutomationRepository companyAutomationRepository)
        {
            _companyAutomationRepository = companyAutomationRepository;
        }
        public async Task<List<CompanyAutomation>> ExecuteAsync()
        {
            return await _companyAutomationRepository.GetAll();
        }
    }
}
