using Bridgeline.Automation.Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace Bridgeline.Automation.Infraestructure.Data
{
    public class AutomationContext : DbContext
    {
        public AutomationContext(DbContextOptions<AutomationContext> options) : base(options) { }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<AutomationExecutionLog> ExecutionLogs { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProviderService> ProviderServices { get; set; }
        public DbSet<CompanyAutomation> CompanyAutomations { get; set; }
        public DbSet<CompanyIntegration> CompanyIntegrations{ get;set; }
        public DbSet<TypeAutomation> TypeAutomations { get; set; }

    }
}
