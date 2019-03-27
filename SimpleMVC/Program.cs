using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using SimpleMVC.Metrics.Extensions;

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
                .UseStartup<Startup>()
                .UseAppMetrics();

    }
}