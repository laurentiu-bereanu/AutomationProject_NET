using System.Reflection;
using log4net;
using log4net.Config;

namespace AutomationProject_NET.AutomationFramework.Configuration
{
    public static class LogInitializer
    {
        public static readonly ILog Log = LogManager.GetLogger("GlobalLogger");

        public static void Initialize()
        {
            var entryAssembly = Assembly.GetExecutingAssembly();
            var logRepository = LogManager.GetRepository(entryAssembly);

            var log4netConfigPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "AutomationFramework",
                "Configuration",
                "Resources",
                "log4net.config");

            if (!File.Exists(log4netConfigPath))
                throw new FileNotFoundException($"Cannot find log4net config file at {log4netConfigPath}");

            XmlConfigurator.Configure(logRepository, new FileInfo(log4netConfigPath));
        }
    }
}
