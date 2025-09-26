using Bridgeline.Automation.Application.DTOs.CompanyAutomations;
using Bridgeline.Automation.Application.Exceptions;
using Bridgeline.Automation.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bridgeline.Automation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyAutomationController : ControllerBase
    {
        private readonly ILogger<CompanyAutomationController> _logger;
        private readonly ICompanyAutomationService  _companyAutomation;
        public CompanyAutomationController(ILogger<CompanyAutomationController> logger, ICompanyAutomationService companyAutomation)
        {
            _logger = logger;
             _companyAutomation = companyAutomation;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PostCompanyAutomationDto companyAutomationDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var data = await  _companyAutomation.CreateCompanyAutomationAsync(companyAutomationDto);

                if (data == null)
                {
                    return BadRequest($"Company automation {companyAutomationDto.Name} creation failed");
                }

                return Ok(data);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "Not Found in CompanyAutomationController Post method");
                return NotFound(ex.Message);
            }
            catch (ConflictException ex)
            {
                _logger.LogError(ex, "Conflict in CompanyAutomationController Post method");
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CompanyAutomationController Post method");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(Guid id, [FromBody] PutCompanyAutomationDto companyAutomationDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var data = await  _companyAutomation.UpdateCompanyAutomationAsync(id, companyAutomationDto);

                if (data == null)
                {
                    return BadRequest("Company automation update failed");
                }
                return Ok(data);
            }
            catch (ConflictException ex)
            {
                _logger.LogError(ex, "Conflict in CompanyAutomationController Put method");
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CompanyAutomationController Put method");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var data = await  _companyAutomation.GetCompanyAutomationAsync(id);
                if (data == null)
                {
                    return NotFound($"Company automation with ID '{id}' not found");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CompanyAutomationController GetById method");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await  _companyAutomation.GetCompanyAutomationsAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CompanyAutomationController Get method");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await  _companyAutomation.DeleteCompanyAutomationAsync(id);

                if (!result)
                {
                    return NotFound($"Company integration with ID '{id}' not found or could not be deleted");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CompanyAutomationController Delete method");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
