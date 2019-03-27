using System.Threading;
using System.Threading.Tasks;
using App.Metrics.Health;
using SimpleMVC.Metrics;

namespace SimpleMVC
{
    public class SampleHealthCheck: HealthCheck
    {
        public SampleHealthCheck(): base("Sample Health Check")
        {
        }

        protected override ValueTask<HealthCheckResult> CheckAsync(CancellationToken cancellationToken = default)
        {
            if (!DependencyStatus.Healthy)
            {
                return new ValueTask<HealthCheckResult>(HealthCheckResult.Degraded());
            }

            if (!DbStatus.Healthy)
            {
                return new ValueTask<HealthCheckResult>(HealthCheckResult.Unhealthy());
            }
            
            return new ValueTask<HealthCheckResult>(HealthCheckResult.Healthy());
        }
    }
}