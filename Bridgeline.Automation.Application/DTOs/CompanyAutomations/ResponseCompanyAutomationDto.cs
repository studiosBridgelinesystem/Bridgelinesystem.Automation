using Bridgeline.Automation.Domain.entities;

namespace Bridgeline.Automation.Application.DTOs.CompanyAutomations
{
    public class ResponseCompanyAutomationDto
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid TypeAutomationId { get; set; }
        public string N8nWorkflowId { get; set; }
        public int RunFrequency { get; set; }
        public Dictionary<string, string> Conditions { get; set; }
        public Dictionary<string, string> Tiggers { get; set; }
        public Dictionary<string, string> Configuration { get; set; }
        public virtual TypeAutomation TypeAutomation { get; set; }

        public ResponseCompanyAutomationDto() { }

        public static ResponseCompanyAutomationDto FromEntity (CompanyAutomation companyAutomation)
        {
            if (companyAutomation == null) return null;
            return new ResponseCompanyAutomationDto
            {
                Id = companyAutomation.Id,
                TenantId = companyAutomation.TenantId ?? Guid.Empty,
                Name = companyAutomation.Name,
                Description = companyAutomation.Description,
                TypeAutomationId = companyAutomation.TypeAutomationId ?? Guid.Empty,
                N8nWorkflowId = companyAutomation.N8nWorkflowId,
                RunFrequency = companyAutomation.RunFrequency,
                Conditions = companyAutomation.Conditions,
                Tiggers = companyAutomation.Tiggers,
                Configuration = companyAutomation.Configuration,
                TypeAutomation = companyAutomation.TypeAutomation
            };
        }
    }
}
