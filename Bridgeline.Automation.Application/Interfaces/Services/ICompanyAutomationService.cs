using Bridgeline.Automation.Application.DTOs.CompanyAutomations;

namespace Bridgeline.Automation.Application.Interfaces.Services
{
    public interface ICompanyAutomationService
    {
        Task<ResponseCompanyAutomationDto> CreateCompanyAutomationAsync(PostCompanyAutomationDto dto);
        Task<ResponseCompanyAutomationDto> UpdateCompanyAutomationAsync(Guid id, PutCompanyAutomationDto dto);
        Task<ResponseCompanyAutomationDto> GetCompanyAutomationAsync(Guid id);
        Task<List<ResponseCompanyAutomationDto>> GetCompanyAutomationsAsync();
        Task<bool> DeleteCompanyAutomationAsync(Guid id);
    }
}
