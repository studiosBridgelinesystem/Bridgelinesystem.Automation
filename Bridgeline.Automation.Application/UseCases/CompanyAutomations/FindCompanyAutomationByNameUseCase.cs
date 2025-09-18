using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.CompanyAutomations
{
    public class FindCompanyAutomationByNameUseCase
    {
        private readonly ICompanyAutomationRepository _companyAutomationRepository;
        public FindCompanyAutomationByNameUseCase(ICompanyAutomationRepository companyAutomationRepository)
        {
            _companyAutomationRepository = companyAutomationRepository;
        }
        public async Task<bool> ExecuteAsync(string name)
        {
            var existingCompanyAutomation = await _companyAutomationRepository.FindByName(name);
            return existingCompanyAutomation != null;
        }
    }
}
