using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;

namespace APIAdvancedSprint.HealthChecks
{
    public class TeachersHealthCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var jsonFilePath = @"Resources\Teachers.json";

            var jsonData = await File.ReadAllTextAsync(jsonFilePath);

            var productsData = JsonSerializer.Deserialize<List<Teacher>>(jsonData);

            int products = productsData.Count();

            if (products > 0)
            {
                return HealthCheckResult.Healthy($"There are {products} products available.");
            }
            else
            {
                return HealthCheckResult.Unhealthy($"There are {products} products available.");
            }
        }
    }
}
