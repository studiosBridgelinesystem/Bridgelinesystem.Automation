using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.TypeAutomations
{
    public class GetTypeAutomationsUseCase
    {
        private readonly ITypeAutomationRepository _typeAutomationRepository;
        public GetTypeAutomationsUseCase(ITypeAutomationRepository typeAutomationRepository)
        {
            _typeAutomationRepository = typeAutomationRepository;
        }

        public async Task<List<TypeAutomation>> ExecuteAsync()
        {
            return await _typeAutomationRepository.GetTypeAutomations();
        }
    }
}
