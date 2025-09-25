using Bridgeline.Automation.Application.DTOs.AutomationExecutionLogs;

namespace Bridgeline.Automation.Application.Interfaces.Services
{
    public interface IAutomationExecutionLogService
    {
        Task<ResponseAutomationExecuteLogDto> CreateAutomationExecuteLogService(PostAutomationExecuteLogDto logDto);
        Task<ResponseAutomationExecuteLogDto> GetAutomationExecuteLogService(Guid id);
        Task<List<ResponseAutomationExecuteLogDto>> GetAutomationExecuteLogsService();
    }
}
