using APIAdvancedSprint.Controllers;
using APIAdvancedSprint.Services;
using APIAdvancedSprint.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using APIAdvancedSprint.HealthChecks;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

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
            builder.Services.AddScoped<TeachersModel>();
            builder.Services.AddScoped<TeachersService>();

            builder.Services.AddRateLimiter(options =>
            {
                options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
                options.AddFixedWindowLimiter(policyName: "fixedSpell", options =>
                {
                    options.PermitLimit = 3;
                    options.Window = TimeSpan.FromMinutes(1);
                    options.QueueLimit = 2;
                    options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                    
                });
            });

            builder.Services.AddHealthChecks()
                            .AddCheck<TeachersHealthCheck>("teachers_file_health_check",
                                failureStatus: HealthStatus.Unhealthy,
                                tags: new[] { "file", "teachers" });

            var app = builder.Build();

            app.UseHealthChecks("/health");

            app.UseRouting();

            app.UseRateLimiter();

            app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapControllers();//.RequireRateLimiting("fixedSpell");  // discard pattern '_' ignores the return value of 'MapControllers' because no further configuration of the endpoints is required
            });

            app.Run();
        }
    }
}
