using APIAdvancedSprint.Controllers;
using APIAdvancedSprint.Services;
using APIAdvancedSprint.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using APIAdvancedSprint.HealthChecks;

namespace APIAdvancedSprint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddScoped<SpellsModel>();
            builder.Services.AddScoped<SpellsService>();

            builder.Services.AddHealthChecks()
                            .AddCheck<TeachersHealthCheck>("teachers_file_health_check",
                                failureStatus: HealthStatus.Unhealthy,
                                tags: new[] { "file", "teachers" });

            var app = builder.Build();

            app.UseHealthChecks("/health");

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapControllers();  // discard pattern '_' ignores the return value of 'MapControllers' because no further configuration of the endpoints is required
            });

            app.Run();
        }
    }
}
