using Bridgeline.Automation.Application.DTOs.TypeAutomations;

namespace Bridgeline.Automation.Application.Interfaces.Services
{
    public interface ITypeAutomationService
    {
        Task<ResponseTypeAutomationDto> CreateTypeAutomationService(PostTypeAutomationDto typeAutomationDto);

        Task<ResponseTypeAutomationDto> UpdateTypeAutomationService(Guid id, PutTypeAutomationDto typeAutomationDto);

        Task<ResponseTypeAutomationDto> GetTypeAutomationService(Guid id);

        Task<List<ResponseTypeAutomationDto>> GetTypeAutomationsService();

        Task<bool> DeleteTypeAutomationService(Guid id);
    }
}
