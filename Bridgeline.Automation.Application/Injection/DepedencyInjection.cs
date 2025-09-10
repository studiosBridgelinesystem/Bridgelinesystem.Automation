using Bridgeline.Automation.Application.UseCases.Providers;
using Bridgeline.Automation.Application.UseCases.Statuses;
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
            services.AddScoped<GetStatusUseCase>();
            services.AddScoped<GetStatusesUseCase>();
            services.AddScoped<FindByNameStatusUseCase>();
            services.AddScoped<DeleteStatusUseCase>();

            // PROVIDER
            services.AddScoped<CreateProviderUseCase>();
            services.AddScoped<FindByNameProviderUseCase>();
            services.AddScoped<GetProviderUseCase>();
            services.AddScoped<UpdateProviderUseCase>();

            return services;
        }
    }
}
