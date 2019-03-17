using App.Metrics.AspNetCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace SimpleMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseMetricsWebTracking()
                .UseMetricsEndpoints()
                //.UseHealth()
                .UseHealthEndpoints()
                .UseMetrics()
                .UseStartup<Startup>();
    }
}