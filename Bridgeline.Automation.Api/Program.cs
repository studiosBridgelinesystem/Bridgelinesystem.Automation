using Bridgeline.Automation.Api.Middlewares;
using Bridgeline.Automation.Application.Injection;
using Bridgeline.Automation.Infraestructure.Data;
using Bridgeline.Automation.Infraestructure.Injection;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AutomationContext>(options => 
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddInfraestructureServices();
builder.Services.AddApplicationServices();



builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();


app.MapControllers();

app.Run();
