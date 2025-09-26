using Bridgeline.Automation.Application.DTOs.CompanyIntegrations;
using Bridgeline.Automation.Application.Exceptions;
using Bridgeline.Automation.Application.UseCases.ProviderServices;
using Bridgeline.Automation.Application.UseCases.Statuses;
using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.CompanyIntegrations
{
    public class CreateCompanyIntegrationUseCase
    {
        private readonly ICompanyIntegrationRepository _companyIntegrationRepository;
        private readonly GetProviderServiceUseCase _getProviderServiceUseCase;
        private readonly GetStatusUseCase _getStatusUseCase;
        public CreateCompanyIntegrationUseCase(ICompanyIntegrationRepository companyIntegrationRepository, GetProviderServiceUseCase getProviderServiceUseCase, GetStatusUseCase getStatusUseCase)
        {
            _companyIntegrationRepository = companyIntegrationRepository;
            _getProviderServiceUseCase = getProviderServiceUseCase;
            _getStatusUseCase = getStatusUseCase;
        }
        public async Task<CompanyIntegration> ExecuteAsync(PostCompanyIntegrationDto dto)
        {

            _ = await _getProviderServiceUseCase.ExecuteAsync(dto.ProviderServiceId) ?? throw new NotFoundException($"Provider Service with id {dto.ProviderServiceId} not found.");

            _ = await  _getStatusUseCase.ExecuteAsync(dto.StatusId) ?? throw new NotFoundException($"Status with id {dto.StatusId} not found.");

            var ExistingCompanyIntegration = await _companyIntegrationRepository.FindByName(dto.Name);

            if (ExistingCompanyIntegration != null) {
                throw new ConflictException($"The name {dto.Name} already exists.");
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
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true
            };

            return await _companyIntegrationRepository.Create(newCompanyIntegration);

        }
    }
}
