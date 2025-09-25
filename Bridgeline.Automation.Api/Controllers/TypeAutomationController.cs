using Bridgeline.Automation.Application.DTOs.TypeAutomations;
using Bridgeline.Automation.Application.Exceptions;
using Bridgeline.Automation.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bridgeline.Automation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeAutomationController : ControllerBase
    {
        private readonly ILogger<TypeAutomationController> _logger;
        private readonly ITypeAutomationService _typeAutomationServices;
        public TypeAutomationController
        (
            ILogger<TypeAutomationController> logger, 
            ITypeAutomationService typeAutomationServices
        )
        {
            _logger = logger;
            _typeAutomationServices = typeAutomationServices;
        }

        [HttpPost]
        public async Task<ActionResult> Post(PostTypeAutomationDto typeAutomationDto)
        {
            try
            {
                var data = await _typeAutomationServices.CreateTypeAutomationService(typeAutomationDto);

                if (data == null)
                {
                    return BadRequest($"Type automation {typeAutomationDto.Name} creation failed");
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

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(Guid id, PutTypeAutomationDto typeAutomationDto)
        {
            try
            {
                var data = await _typeAutomationServices.UpdateTypeAutomationService(id,typeAutomationDto);

                if (data == null)
                {
                    return BadRequest("Status update failed");
                }
                return Ok(data);
            }
            catch (ConflictException ex)
            {
                _logger.LogError(ex, "Conflict in TypeAutomationController Put method");
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in TypeAutomationController Put method");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var data = await _typeAutomationServices.GetTypeAutomationService(id);
                if (data == null)
                {
                    return NotFound($"TypeAutomation with ID '{id}' not found");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in TypeAutomationController GetById method");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _typeAutomationServices.GetTypeAutomationsService();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in TypeAutomationController Get method");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _typeAutomationServices.DeleteTypeAutomationService(id);
                if (!result)
                {
                    return NotFound($"Type Automation with ID '{id}' not found or could not be deleted");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in TypeAutomationController Delete method");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
