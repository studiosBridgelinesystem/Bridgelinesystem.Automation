using Bridgeline.Automation.Application.DTOs.CompanyIntegrations;
using Bridgeline.Automation.Application.UseCases.ProviderServices;
using Bridgeline.Automation.Application.UseCases.Statuses;
using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.CompanyIntegrations
{
    public class UpdateCompanyIntegrationUseCase
    {
        private readonly ICompanyIntegrationRepository _companyIntegrationRepository;
        private readonly GetStatusUseCase _getStatusUseCase;
        private readonly GetProviderServiceUseCase _getProviderServiceUseCase;
        public UpdateCompanyIntegrationUseCase(ICompanyIntegrationRepository companyIntegrationRepository, GetStatusUseCase getStatusUseCase, GetProviderServiceUseCase getProviderServiceUseCase)
        {
            _companyIntegrationRepository = companyIntegrationRepository;
            _getStatusUseCase = getStatusUseCase;
            _getProviderServiceUseCase = getProviderServiceUseCase;
        }
        public async Task<CompanyIntegration> ExecuteAsync(Guid id, PutCompanyIntegrationDto dto)
        {
            var existingCompanyIntegration = await _companyIntegrationRepository.GetById(id) ?? throw new Exception("Company Integration not found.");


            if(dto.Name != null)
            {
                var existingName = await _companyIntegrationRepository.FindByName(dto.Name);

                if (existingName != null && existingName.Id != id)
                {
                    throw new Exception("A Company Integration with the same name already exists.");
                }
            }

            if(dto.StatusId != null)
            {
                var validStatus = await _getStatusUseCase.ExecuteAsync((Guid)dto.StatusId) ?? throw new Exception("Status not found.");
            }

            if(dto.ProviderServiceId != null)
            {
                var validProviderService = await _getProviderServiceUseCase.ExecuteAsync((Guid)dto.ProviderServiceId) ?? throw new Exception("Provider Service not found.");
            }

            existingCompanyIntegration.Name = dto.Name ?? existingCompanyIntegration.Name;
            existingCompanyIntegration.Credentials = dto.Credentials ?? existingCompanyIntegration.Credentials;
            existingCompanyIntegration.Configuration = dto.Configuration ?? existingCompanyIntegration.Configuration;
            existingCompanyIntegration.StatusId = dto.StatusId ?? existingCompanyIntegration.StatusId;
            existingCompanyIntegration.ProviderServiceId = dto.ProviderServiceId ?? existingCompanyIntegration.ProviderServiceId;
            existingCompanyIntegration.UpdatedAt = DateTime.UtcNow;
            
            
            return await _companyIntegrationRepository.Update(id, existingCompanyIntegration);
        }

    }
}
