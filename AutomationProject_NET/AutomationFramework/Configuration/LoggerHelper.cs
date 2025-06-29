using log4net;

namespace AutomationProject_NET.AutomationFramework.Configuration
{
        public static class LoggerHelper
        {
            public static readonly ILog Log = LogManager.GetLogger("GlobalLogger");
        }
}
