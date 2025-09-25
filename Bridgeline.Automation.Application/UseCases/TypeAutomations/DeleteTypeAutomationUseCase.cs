using Bridgeline.Automation.Domain.Interfaces.Repositories;


namespace Bridgeline.Automation.Application.UseCases.TypeAutomations
{
    public class DeleteTypeAutomationUseCase
    {
        private readonly ITypeAutomationRepository _typeAutomationRepository;
        public DeleteTypeAutomationUseCase(ITypeAutomationRepository typeAutomationRepository)
        {
            _typeAutomationRepository = typeAutomationRepository;
        }
        public async Task<bool> ExecuteAsync(Guid id)
        {
            var typeAutomation = await _typeAutomationRepository.GetById(id) ?? throw new KeyNotFoundException($"TypeAutomation with id {id} not found.");

           return await _typeAutomationRepository.Delete(id);
        }
    }
}
