using Bridgeline.Automation.Application.DTOs.AutomationExecutionLogs;
using Bridgeline.Automation.Application.Interfaces.Services;
using Bridgeline.Automation.Application.UseCases.AutomationExecutionLogs;

namespace Bridgeline.Automation.Application.Services
{
    public class AutomationExecutionLogService : IAutomationExecutionLogService
    {
        private readonly CreateAutomationExecuteUseCase _createAutomationExecuteUseCase;
        private readonly GetAutomationExecuteLogUseCase _getAutomationExecuteLogUseCase;
        private readonly GetAutomationExecuteLogsUseCase _getAutomationExecutionLogsUseCase;

        public AutomationExecutionLogService(
            CreateAutomationExecuteUseCase createAutomationExecuteUseCase, 
            GetAutomationExecuteLogUseCase getAutomationExecuteLogUseCase, 
            GetAutomationExecuteLogsUseCase getAutomationExecutionLogsUseCase)
        {
            _createAutomationExecuteUseCase = createAutomationExecuteUseCase;
            _getAutomationExecuteLogUseCase = getAutomationExecuteLogUseCase;
            _getAutomationExecutionLogsUseCase = getAutomationExecutionLogsUseCase;
        }

        public async Task<ResponseAutomationExecuteLogDto> CreateAutomationExecuteLogService(PostAutomationExecuteLogDto logDto)
        {
           var data =  await _createAutomationExecuteUseCase.ExecuteAsync(logDto);
           return ResponseAutomationExecuteLogDto.FromEntity(data);
        }
        public async Task<ResponseAutomationExecuteLogDto> GetAutomationExecuteLogService(Guid id)
        {
            var data = await _getAutomationExecuteLogUseCase.ExecuteAsync(id);
            return ResponseAutomationExecuteLogDto.FromEntity(data);
        }

        public async Task<List<ResponseAutomationExecuteLogDto>> GetAutomationExecuteLogsService()
        {
            var data = await _getAutomationExecutionLogsUseCase.ExecuteAsync();
            return ResponseAutomationExecuteLogDto.FromEntities(data);
        }
    }
}
