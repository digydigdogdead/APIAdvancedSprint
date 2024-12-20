using APIAdvancedSprint.Controllers;
using APIAdvancedSprint.Services;
using APIAdvancedSprint.Models;

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

            var app = builder.Build();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapControllers();  // discard pattern '_' ignores the return value of 'MapControllers' because no further configuration of the endpoints is required
            });

            app.Run();
        }
    }
}
