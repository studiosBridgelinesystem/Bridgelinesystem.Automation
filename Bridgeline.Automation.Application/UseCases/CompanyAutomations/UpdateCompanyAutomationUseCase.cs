using Bridgeline.Automation.Application.DTOs.CompanyAutomations;
using Bridgeline.Automation.Application.Exceptions;
using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.CompanyAutomations
{
    public class UpdateCompanyAutomationUseCase
    {
        private readonly ICompanyAutomationRepository _companyAutomationRepository;
        public UpdateCompanyAutomationUseCase(ICompanyAutomationRepository companyAutomationRepository)
        {
            _companyAutomationRepository = companyAutomationRepository;
        }

        public async Task<CompanyAutomation> ExecuteAsync (Guid id, PutCompanyAutomationDto companyAutomation)
        {

            var existingCompanyAutomation = await _companyAutomationRepository.GetById(id) ?? throw new NotFoundException($"Company with id: {id} Automation not found.");

            var existingName = await _companyAutomationRepository.FindByName(companyAutomation.Name);

            if(existingName != null && existingName.Id != id)
            {
                throw new ConflictException("A Company Automation with the same name already exists.");
            }

            existingCompanyAutomation.Name = companyAutomation.Name ?? existingCompanyAutomation.Name;
            existingCompanyAutomation.Description = companyAutomation.Description ?? existingCompanyAutomation.Description;
            existingCompanyAutomation.TypeAutomationId = companyAutomation.TypeAutomationId ?? existingCompanyAutomation.TypeAutomationId;
            existingCompanyAutomation.N8nWorkflowId = companyAutomation.N8nWorkflowId ?? existingCompanyAutomation.N8nWorkflowId;
            existingCompanyAutomation.RunFrequency = companyAutomation.RunFrequency ?? existingCompanyAutomation.RunFrequency;
            existingCompanyAutomation.Conditions = companyAutomation.Conditions ?? existingCompanyAutomation.Conditions;
            existingCompanyAutomation.Tiggers = companyAutomation.Tiggers ?? existingCompanyAutomation.Tiggers;
            existingCompanyAutomation.Configuration = companyAutomation.Configuration ?? existingCompanyAutomation.Configuration;
            existingCompanyAutomation.IsActive = existingCompanyAutomation.IsActive;
            existingCompanyAutomation.UpdatedAt = DateTime.UtcNow;

            return await _companyAutomationRepository.Update(existingCompanyAutomation);
        }
    }
}
