using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Passes.API.GetAllPasses;
using Passes.API.MarkPassAsExpired;

namespace Passes.API
{
    internal static class PassesEndpoint
    {
        public static void MapPassesEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapMarkPassAsExpiredEndpoint();
            app.MapGetAllPassesEndpoint();
        }
    }
}
