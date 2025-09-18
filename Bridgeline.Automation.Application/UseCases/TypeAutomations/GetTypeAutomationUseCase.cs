using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.TypeAutomations
{
    public class GetTypeAutomationUseCase
    {
        private readonly ITypeAutomationRepository _typeAutomationRepository;
        public GetTypeAutomationUseCase(ITypeAutomationRepository typeAutomationRepository)
        {
            _typeAutomationRepository = typeAutomationRepository;
        }
        public async Task<TypeAutomation> ExecuteAsync(Guid id)
        {
            return await _typeAutomationRepository.GetById(id);
        }
    }
}
