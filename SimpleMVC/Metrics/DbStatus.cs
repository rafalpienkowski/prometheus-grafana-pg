namespace SimpleMVC.Metrics
{
    public static class DbStatus
    {
        public static bool Healthy { get; private set; } = true;

        public static void Toogle()
        {
            Healthy = !Healthy;
        }
    }

    public class DependencyStatus
    {
        public static bool Healthy { get; private set; } = true;

        public static void Toogle()
        {
            Healthy = !Healthy;
        }
    }
}