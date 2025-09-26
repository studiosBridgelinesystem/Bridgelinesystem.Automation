using Bridgeline.Automation.Application.DTOs.Providers;
using Bridgeline.Automation.Application.DTOs.ProviderServices;
using Bridgeline.Automation.Application.Exceptions;
using Bridgeline.Automation.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bridgeline.Automation.Api.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class ProviderController : ControllerBase
    {

        private readonly ILogger<ProviderController> _logger;
        private readonly IProviderService _provider;
        public ProviderController(ILogger<ProviderController> logger, IProviderService provider)
        {
            _logger = logger;
            _provider = provider;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PostProviderDto providerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var data = await _provider.CreateProviderAsync(providerDto);

                if (data == null)
                {
                    return BadRequest($"Provider {providerDto.Name} creation failed");
                }

                return Ok(data);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "Not Found in ProviderController Post method");
                return NotFound(ex.Message);
            }
            catch (ConflictException ex)
            {
                _logger.LogError(ex, "Conflict in ProviderController Post method");
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ProviderController Post method");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(Guid id, [FromBody] PutProviderDto providerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var data = await _provider.UpdateProviderAsync(id, providerDto);

                if (data == null)
                {
                    return BadRequest("Provider update failed");
                }
                return Ok(data);
            }
            catch (ConflictException ex)
            {
                _logger.LogError(ex, "Conflict in ProviderController Put method");
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ProviderController Put method");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var data = await _provider.GetProviderAsync(id);
                if (data == null)
                {
                    return NotFound($"Provider with ID '{id}' not found");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ProviderController GetById method");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _provider.GetProvidersAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ProviderController Get method");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _provider.DeleteProviderAsync(id);

                if (!result)
                {
                    return NotFound($"Provider with ID '{id}' not found or could not be deleted");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ProviderController Delete method");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

