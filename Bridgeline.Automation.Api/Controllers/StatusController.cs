using Bridgeline.Automation.Application.DTOs.Statuses;
using Bridgeline.Automation.Application.Exceptions;
using Bridgeline.Automation.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bridgeline.Automation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly ILogger<StatusController> _logger;
        private readonly IStatusServices _statusServices;
        public StatusController(ILogger<StatusController> logger, IStatusServices statusServices)
        {
            _logger = logger;
            _statusServices = statusServices;
        }

        [HttpPost]
        public async  Task<ActionResult> Post(PostStatusDto statusDto)
        {
            try
            {
                var data = await _statusServices.CreateStatusService(statusDto);

                if (data == null)
                {
                    return BadRequest("Status creation failed");
                }

                return Ok(data);
            }
            catch (ConflictException ex)
            {
                _logger.LogError(ex, "Conflict in StatusController Post method");
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in StatusController Post method");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, PutStatusDto statusDto)
        {
            try
            {
                var data = await _statusServices.UpdateStatusService(id, statusDto);

                if (data == null)
                {
                    return BadRequest("Status update failed");
                }
                return Ok(data);
            }
            catch (ConflictException ex)
            {
                _logger.LogError(ex, "Conflict in StatusController Put method");
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in StatusController Put method");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var data = await _statusServices.GetStatusService(id);
                if (data == null)
                {
                    return NotFound($"Status with ID '{id}' not found");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in StatusController GetById method");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _statusServices.GetStatusesService();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in StatusController Get method");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _statusServices.DeleteStatusService(id);
                if (!result)
                {
                    return NotFound($"Status with ID '{id}' not found or could not be deleted");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in StatusController Delete method");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
