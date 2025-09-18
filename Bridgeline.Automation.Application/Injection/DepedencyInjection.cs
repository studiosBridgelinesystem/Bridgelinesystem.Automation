using Bridgeline.Automation.Application.UseCases.AutomationExecutionLogs;
using Bridgeline.Automation.Application.UseCases.CompanyAutomations;
using Bridgeline.Automation.Application.UseCases.CompanyIntegrations;
using Bridgeline.Automation.Application.UseCases.Providers;
using Bridgeline.Automation.Application.UseCases.ProviderServices;
using Bridgeline.Automation.Application.UseCases.Statuses;
using Bridgeline.Automation.Application.UseCases.TypeAutomations;
using Microsoft.Extensions.DependencyInjection;
namespace Bridgeline.Automation.Application.Injection
{
    public static class DepedencyInjection 
    {
        public static IServiceCollection AddApplicationServices (this IServiceCollection services)
        {
           // STATUS
            services.AddScoped<CreateStatusUseCase>();
            services.AddScoped<UpdateStatusUseCase>();
            services.AddScoped<FindByNameStatusUseCase>();
            services.AddScoped<GetStatusUseCase>();
            services.AddScoped<GetStatusesUseCase>();
            services.AddScoped<DeleteStatusUseCase>();

            // PROVIDER
            services.AddScoped<CreateProviderUseCase>();
            services.AddScoped<UpdateProviderUseCase>();
            services.AddScoped<FindByNameProviderUseCase>();
            services.AddScoped<GetProviderUseCase>();
            services.AddScoped<DeleteProviderUseCase>();

            // PROVIDER SERVICE
            services.AddScoped<CreateProviderServicesUseCase>();
            services.AddScoped<UpdateProviderServiceUseCase>();
            services.AddScoped<FindProviderServiceByNameUseCase>();
            services.AddScoped<GetProviderServiceUseCase>();
            services.AddScoped<GetProviderServicesUseCase>();
            services.AddScoped<DeleteProviderServiceUseCase>();

            // TYPE AUTOMATION
            services.AddScoped<CreateTypeAutomationUseCase>();
            services.AddScoped<UpdateTypeAutomationUseCase>();
            services.AddScoped<FindTypeAutomationByNameUseCase>();
            services.AddScoped<GetTypeAutomationUseCase>();
            services.AddScoped<GetTypeAutomationsUseCase>();
            services.AddScoped<DeleteTypeAutomationUseCase>();

            // COMPANY INTEGRATION
            services.AddScoped<CreateCompanyIntegrationUseCase>();
            services.AddScoped<UpdateCompanyIntegrationUseCase>();
            services.AddScoped<FindCompanyIntegrationByNameUseCase>();
            services.AddScoped<GetCompanyIntegrationUseCase>();
            services.AddScoped<GetCompanyIntegrationsUseCase>();
            services.AddScoped<DeleteCompanyIntegrationUseCase>();

            // COMPANY AUTOMATION
            services.AddScoped<CreateCompanyAutomationUseCase>();
            services.AddScoped<UpdateCompanyAutomationUseCase>();
            services.AddScoped<FindCompanyAutomationByNameUseCase>();
            services.AddScoped<GetCompanyAutomationUseCase>();
            services.AddScoped<GetCompanyAutomationsUseCase>();
            services.AddScoped<DeleteCompanyAutomationUseCase>();

            // AUTOMATION EXECUTION
            services.AddScoped<CreateAutomationExecuteUseCase>();
            services.AddScoped<GetAutomationExecuteLogsUseCase>();
            services.AddScoped<GetAutomationExecuteLogUseCase>();

            return services;
        }
    }
}
