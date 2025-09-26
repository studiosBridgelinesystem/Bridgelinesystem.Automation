using Bridgeline.Automation.Application.DTOs.ProviderServices;
using Bridgeline.Automation.Application.Exceptions;
using Bridgeline.Automation.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bridgeline.Automation.Api.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class ProviderServicesController : ControllerBase
    {
        private readonly ILogger<ProviderServicesController> _logger;
        private readonly IProviderServicesService _providerService;
        public ProviderServicesController(ILogger<ProviderServicesController> logger, IProviderServicesService providerService)
        {
            _logger = logger;
            _providerService = providerService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PostProviderServiceDto providerServiceDto)
        {
            try
            {
                if (!ModelState.IsValid)  return BadRequest(ModelState);
                
                var data = await _providerService.CreateProviderServiceAsync(providerServiceDto);

                if (data == null)
                {
                    return BadRequest($"Provider Service {providerServiceDto.Name} creation failed");
                }

                return Ok(data);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "Not Found in ProviderServiceController Post method");
                return NotFound(ex.Message);
            }
            catch (ConflictException ex )
            {
                _logger.LogError(ex, "Conflict in ProviderServiceController Post method");
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ProviderServiceController Post method");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(Guid id,  [FromBody]PutProviderServiceDto providerServiceDto)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);

                var data = await _providerService.UpdateProviderServiceAsync(id, providerServiceDto);

                if (data == null)
                {
                    return BadRequest("Provider service update failed");
                }
                return Ok(data);
            }
            catch (ConflictException ex)
            {
                _logger.LogError(ex, "Conflict in ProviderServiceController Put method");
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ProviderServiceController Put method");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var data = await _providerService.GetProviderServiceAsync(id);
                if (data == null)
                {
                    return NotFound($"Provider service with ID '{id}' not found");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ProviderServiceController GetById method");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _providerService.GetProviderServicesAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ProviderServiceController Get method");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                { 
                    return BadRequest(); 
                }

                var result = await _providerService.DeleteProviderServiceAsync(id);

                if (!result)
                {
                    return NotFound($"Provider service with ID '{id}' not found or could not be deleted");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ProviderServiceController Delete method");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
