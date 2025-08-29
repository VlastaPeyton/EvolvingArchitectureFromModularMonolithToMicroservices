
using Microsoft.Extensions.Configuration;

namespace Common.Infrastructure.Modules
{
    public static class ModuleAvailabilityChecker
    {
        private const string AvailabilityConfigKeyName = "Enabled";

        public static bool IsModuleEnabled(this IConfiguration configuration, string module)
        {
            return configuration.GetSection(GetModuleConfiguration(module)).GetValue<bool>(AvailabilityConfigKeyName);
        }

        private static string GetModuleConfiguration(string module) => $"Modules:{module}";
    }
}
