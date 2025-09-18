
using Bridgeline.Automation.Application.DTOs.TypeAutomations;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.TypeAutomations
{
    public class UpdateTypeAutomationUseCase
    {
        public readonly ITypeAutomationRepository _typeAutomationRepository;
        public UpdateTypeAutomationUseCase(ITypeAutomationRepository typeAutomationRepository)
        {
            _typeAutomationRepository = typeAutomationRepository;
        }
        public async Task ExecuteAsync(Guid id , PutTypeAutomationDto dto)
        {

            var TypeAutomation = await _typeAutomationRepository.GetById(id) ??  throw new KeyNotFoundException($"TypeAutomation with id {id} not found.");
           
            TypeAutomation.Name = dto.Name ?? TypeAutomation.Name;
            TypeAutomation.Description = dto.Description ?? TypeAutomation.Description;
            TypeAutomation.N8nTemplateId = dto.N8nTemplateId ?? TypeAutomation.N8nTemplateId;
            TypeAutomation.DefaultConfig = dto.DefaultConfig ?? TypeAutomation.DefaultConfig;
            TypeAutomation.UpdatedAt = DateTime.UtcNow;
        
            await _typeAutomationRepository.Update(TypeAutomation);
        }
    }
}
