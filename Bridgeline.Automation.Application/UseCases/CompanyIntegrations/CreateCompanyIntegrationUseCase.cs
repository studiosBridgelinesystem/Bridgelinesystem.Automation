using Bridgeline.Automation.Application.DTOs.CompanyIntegrations;
using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.CompanyIntegrations
{
    public class CreateCompanyIntegrationUseCase
    {
        private readonly ICompanyIntegrationRepository _companyIntegrationRepository;
        public CreateCompanyIntegrationUseCase(ICompanyIntegrationRepository companyIntegrationRepository)
        {
            _companyIntegrationRepository = companyIntegrationRepository;
        }
        public async Task<CompanyIntegration> ExeuteAsync(PostCompanyIntegrationDto dto)
        {

            var ExistingCompanyIntegration = await _companyIntegrationRepository.FindByName(dto.Name);

            if (ExistingCompanyIntegration != null) {
                throw new InvalidOperationException($"The name {dto.Name} already exists.");
            }

            var newCompanyIntegration = new CompanyIntegration
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                TenantId = dto.TenantId,
                StatusId = dto.StatusId,
                ProviderServiceId = dto.ProviderServiceId,
                Configuration = dto.Configuration,
                Credentials = dto.Credentials,
                LastSyncAt = dto.LastSyncAt,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = true
            };

            return await _companyIntegrationRepository.Create(newCompanyIntegration);

        }
    }
}
