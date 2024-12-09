using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutomationProject_NET.AutomationFramework.Configuration
{
    public static class ConfigurationManager
    {
        public static ServiceProvider Initialize()
        {
            const string SETTINGS_FILE_NAME = "appsettings.json";

            const string TEST_SETTINGS_SECTION_NAME = "TestSettings";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AutomationFramework", "Configuration"))
                .AddJsonFile(SETTINGS_FILE_NAME, optional: false, reloadOnChange: true)
                .Build();

            var services = new ServiceCollection();

            var testSettings = configuration.GetSection(TEST_SETTINGS_SECTION_NAME).Get<TestSettings>()
                ?? throw new Exception($"{TEST_SETTINGS_SECTION_NAME} section not found in the configuration file.");

            services.AddSingleton(testSettings);

            return services.BuildServiceProvider();
        }
    }
}
