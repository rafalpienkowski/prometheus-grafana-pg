using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using App.Metrics.Health;
using App.Metrics.Health.Builder;

namespace HealthChecker
{
    class Program
    {
        public static async Task Main()
        {
            Console.WriteLine("Hello World!");

            var health = new HealthBuilder()
                .HealthChecks.AddHttpGetCheck("simple-mvc", new Uri("http://localhost:5000/health"), TimeSpan.FromSeconds(10))
                .Build();
            
            var healthStatus = await health.HealthCheckRunner.ReadAsync();

            using (var stream = new MemoryStream())
            {
                await health.DefaultOutputHealthFormatter.WriteAsync(stream, healthStatus);
                var result = Encoding.UTF8.GetString(stream.ToArray());
                System.Console.WriteLine(result);
            }

            System.Console.ReadKey();
        }
    }
}