using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Passes.DataAccess.Database
{
    internal static class AutoPassesMigrationExtensions
    {
        internal static IApplicationBuilder UseAutoPassesMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<PassesDbContext>();
            context.Database.Migrate();

            return app;
        }
    }
}
