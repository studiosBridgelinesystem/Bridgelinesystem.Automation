using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.CompanyAutomations
{
    public class GetCompanyAutomationUseCase
    {
        private readonly ICompanyAutomationRepository _companyAutomationRepository;
        public GetCompanyAutomationUseCase(ICompanyAutomationRepository companyAutomationRepository)
        {
            _companyAutomationRepository = companyAutomationRepository;
        }
        public async Task<CompanyAutomation> ExecuteAsync(Guid id)
        {
            return await _companyAutomationRepository.GetById(id);
        }
    }
}
