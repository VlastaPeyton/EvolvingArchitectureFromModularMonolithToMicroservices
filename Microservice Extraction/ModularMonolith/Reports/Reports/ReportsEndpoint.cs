using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports
{
    internal static class ReportsEndpoint
    {
        public static void MapReports(this IEndpointRouteBuilder app)
        {
            app.MapGenerateNewPassesRegistrationsPerMonthReport();
        }
    }
}
