using Bridgeline.Automation.Application.DTOs.TypeAutomations;
using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.TypeAutomations
{
    public class CreateTypeAutomationUseCase
    {
        private readonly ITypeAutomationRepository _typeAutomationRepository;
        public CreateTypeAutomationUseCase(ITypeAutomationRepository typeAutomationRepository)
        {
            _typeAutomationRepository = typeAutomationRepository;
        }

        public async Task<TypeAutomation> ExecuteAsync (PostTypeAutomationDto Dto)
        {

            PostTypeAutomationDto typeAutomationDto = Dto ?? throw new ArgumentNullException(nameof(Dto));
            

            var typeAutomation = new TypeAutomation
            {
                Id = Guid.NewGuid(),
                Name = Dto.Name,
                Description = Dto.Description,
                N8nTemplateId = Dto.N8nTemplateId,
                DefaultConfig = Dto.DefaultConfig,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true

            };

            await _typeAutomationRepository.Create(typeAutomation);
            return typeAutomation;
        }
    }
}
