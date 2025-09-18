using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.TypeAutomations
{
    public class FindTypeAutomationByNameUseCase
    {
        private readonly ITypeAutomationRepository _typeAutomationRepository;
        public FindTypeAutomationByNameUseCase(ITypeAutomationRepository typeAutomationRepository)
        {
            _typeAutomationRepository = typeAutomationRepository;
        }
        public async Task<TypeAutomation> ExecuteAsync(string name)
        {
            return await _typeAutomationRepository.FindByName(name);
        }
    }
}
