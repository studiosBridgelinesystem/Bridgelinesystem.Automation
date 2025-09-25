using Bridgeline.Automation.Application.DTOs.CompanyIntegrations;

namespace Bridgeline.Automation.Application.Interfaces.Services
{
    public interface ICompanyIntegrationService
    {
        Task<ResponseCompanyIntegrationDto> CreateCompanyIntegrationAsync(PostCompanyIntegrationDto dto);

        Task<ResponseCompanyIntegrationDto> UpdateCompanyIntegrationAsync(Guid id, PutCompanyIntegrationDto dto);

        Task<ResponseCompanyIntegrationDto> GetCompanyIntegrationAsync(Guid id);

        Task<List<ResponseCompanyIntegrationDto>> GetCompanyIntegrationsAsync();

        Task<bool> DeleteCompanyIntegrationAsync(Guid id);
    }
}
