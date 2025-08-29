namespace Common.Infrastructure.Modules
{
    public static class ModuleAvailabilityChecker
    {
        private const string AvailabilityConfigKeyName = "Enabled";

        public static bool IsModuleEnabled(this IConfiguration configuration, string module)
        {   
            // GetSection iz appsettings.json uzima "Modules" key
            // GetValue<bool>("Enabled") uzima Modules:Enabled key koji ima true/false value
            return configuration.GetSection(GetModuleConfiguration(module)).GetValue<bool>(AvailabilityConfigKeyName);
        }

        private static string GetModuleConfiguration(string module)
        {
            return $"Modules:{module}";
        }
    }
}
