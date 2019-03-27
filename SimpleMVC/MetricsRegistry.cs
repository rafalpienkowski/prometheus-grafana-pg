using App.Metrics;
using App.Metrics.Counter;
using App.Metrics.Gauge;

namespace SimpleMVC
{
    public class MetricsRegistry
    {
        public static CounterOptions HomeCounter => new CounterOptions
        {
            Name = "home",
            MeasurementUnit = Unit.Calls
        };
        
        public static CounterOptions PrivacyCounter => new CounterOptions
        {
            Name = "privacy",
            MeasurementUnit = Unit.Calls
        };
        
        public static GaugeOptions Warning => new GaugeOptions
        {
            Name = "_warning",
            MeasurementUnit = Unit.Warnings
        };

    }
}