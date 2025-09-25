using Bridgeline.Automation.Application.DTOs.CompanyAutomations;
using Bridgeline.Automation.Application.Exceptions;
using Bridgeline.Automation.Application.UseCases.TypeAutomations;
using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.CompanyAutomations
{
    public class CreateCompanyAutomationUseCase
    {
        private readonly ICompanyAutomationRepository _companyAutomationRepository;
        private readonly GetTypeAutomationUseCase _getTypeAutomationUseCase;
        public CreateCompanyAutomationUseCase(
            ICompanyAutomationRepository companyAutomationRepository,
            GetTypeAutomationUseCase getTypeAutomationUseCase   
            )
        {
            _companyAutomationRepository = companyAutomationRepository;
            _getTypeAutomationUseCase = getTypeAutomationUseCase;
        }
        public async Task<CompanyAutomation> ExecuteAsync(PostCompanyAutomationDto dto)
        {
            var existingCompanyAutomation = await _companyAutomationRepository.FindByName(dto.Name);
            if (existingCompanyAutomation != null)
            {
                throw new ConflictException("A Company Automation with the same name already exists.");
            }

            var existingTypeAutomation = await _getTypeAutomationUseCase.ExecuteAsync(dto.TypeAutomationId) ?? throw new NotFoundException("Type Automation not found.");

            var companyAutomation = new CompanyAutomation
            {
                Id = Guid.NewGuid(),
                TenantId = dto.TenantId,
                Name = dto.Name,
                Description = dto.Description,
                TypeAutomationId = dto.TypeAutomationId,
                N8nWorkflowId = dto.N8nWorkflowId,
                RunFrequency = dto.RunFrequency,
                Conditions = dto.Conditions,
                Tiggers = dto.Tiggers,
                Configuration = dto.Configuration,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            return await _companyAutomationRepository.Create(companyAutomation);
        }
    }
}
