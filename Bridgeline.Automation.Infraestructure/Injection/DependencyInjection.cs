using Bridgeline.Automation.Domain.Interfaces.Repositories;
using Bridgeline.Automation.Infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Bridgeline.Automation.Infraestructure.Injection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructureServices ( this IServiceCollection services )
        {
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IProviderServiceRepository, ProviderServiceRepository>();

            services.AddScoped<ICompanyIntegrationRepository, CompanyIntegrationRepository>();
            services.AddScoped<ICompanyAutomationRepository, CompanyAutomationRepositoy>();
            services.AddScoped<ITypeAutomationRepository, TypeAutomationRepository>();
            services.AddScoped<IAutomationExecutionLogRepository, AutomationExecutionLogRepository>();

            services.AddScoped<IStatusRepository, StatusRepository>();

            return services;
        }
    }
}
