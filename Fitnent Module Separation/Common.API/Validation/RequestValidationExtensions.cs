using System.Reflection;
using FluentValidation;

namespace Common.API.Validation
{
    public static class RequestValidationExtensions
    {
        public static IServiceCollection AddRequestValidation(this IServiceCollection services, Assembly assembly)
        {
            services.AddValidatorsFromAssembly(assembly, includeInternalTypes: true);
            return services;
        }
    }
}
