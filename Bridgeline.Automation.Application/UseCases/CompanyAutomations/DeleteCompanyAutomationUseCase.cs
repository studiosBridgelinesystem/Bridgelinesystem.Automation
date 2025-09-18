using Bridgeline.Automation.Domain.Interfaces.Repositories;


namespace Bridgeline.Automation.Application.UseCases.CompanyAutomations
{
    public class DeleteCompanyAutomationUseCase
    {
        private readonly ICompanyAutomationRepository _companyAutomationRepository;
        public DeleteCompanyAutomationUseCase(ICompanyAutomationRepository companyAutomationRepository)
        {
            _companyAutomationRepository = companyAutomationRepository;
        }
        public async Task<bool> ExecuteAsync(Guid id)
        {
            return await _companyAutomationRepository.Delete(id);
        }
    }
}
