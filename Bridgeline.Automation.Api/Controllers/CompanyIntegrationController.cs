
using Bridgeline.Automation.Application.DTOs.CompanyIntegrations;
using Bridgeline.Automation.Application.Exceptions;
using Bridgeline.Automation.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bridgeline.Automation.Api.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class CompanyIntegrationController : ControllerBase
    {

        private readonly ILogger<CompanyIntegrationController> _logger;
        private readonly ICompanyIntegrationService  _companyIntegration;
        public CompanyIntegrationController(ILogger<CompanyIntegrationController> logger, ICompanyIntegrationService companyIntegration)
        {
            _logger = logger;
             _companyIntegration = companyIntegration;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PostCompanyIntegrationDto companyIntegrationDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var data = await  _companyIntegration.CreateCompanyIntegrationAsync(companyIntegrationDto);

                if (data == null)
                {
                    return BadRequest($"Company integration {companyIntegrationDto.Name} creation failed");
                }

                return Ok(data);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "Not Found in CompanyIntegrationController Post method");
                return NotFound(ex.Message);
            }
            catch (ConflictException ex)
            {
                _logger.LogError(ex, "Conflict in CompanyIntegrationController Post method");
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CompanyIntegrationController Post method");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(Guid id, [FromBody] PutCompanyIntegrationDto companyIntegrationDto) { 
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var data = await _companyIntegration.UpdateCompanyIntegrationAsync(id, companyIntegrationDto);

                if (data == null)
                {
                    return BadRequest("Company integration update failed");
                }
                return Ok(data);
            }
            catch (ConflictException ex)
            {
                _logger.LogError(ex, "Conflict in CompanyIntegrationController Put method");
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CompanyIntegrationController Put method");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var data = await _companyIntegration.GetCompanyIntegrationAsync(id);
                if (data == null)
                {
                    return NotFound($"Company integration with ID '{id}' not found");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CompanyIntegrationController GetById method");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _companyIntegration.GetCompanyIntegrationsAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CompanyIntegrationController Get method");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _companyIntegration.DeleteCompanyIntegrationAsync(id);

                if (!result)
                {
                    return NotFound($"Company integration with ID '{id}' not found or could not be deleted");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CompanyIntegrationController Delete method");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

