using Bridgeline.Automation.Application.DTOs.AutomationExecutionLogs;
using Bridgeline.Automation.Application.Exceptions;
using Bridgeline.Automation.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bridgeline.Automation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutomationExecutionController : ControllerBase
    {
        private readonly ILogger<AutomationExecutionController> _logger;
        private readonly IAutomationExecutionLogService _automationLogs;
        public AutomationExecutionController(ILogger<AutomationExecutionController> logger, IAutomationExecutionLogService automationExecutionLog)
        {
            _logger = logger;
            _automationLogs = automationExecutionLog;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PostAutomationExecuteLogDto automationLogDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var data = await _automationLogs.CreateAutomationExecuteLogService(automationLogDto);

                if (data == null)
                {
                    return BadRequest($"Automation log creation failed");
                }

                return Ok(data);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "Not Found in automationLogController Post method");
                return NotFound(ex.Message);
            }
            catch (ConflictException ex)
            {
                _logger.LogError(ex, "Conflict in automationLogController Post method");
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in automationLogController Post method");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var data = await _automationLogs.GetAutomationExecuteLogService(id);
                if (data == null)
                {
                    return NotFound($"Automation log with ID '{id}' not found");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in automationLogController GetById method");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _automationLogs.GetAutomationExecuteLogsService();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in automationLogController Get method");
                return StatusCode(500, "Internal server error");

            }
        }
    }
}
