using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.API.GetAllPasses
{
    internal record GetAllPassesResponse(IReadOnlyCollection<PassDTO> Passes)
    {
        public static GetAllPassesResponse Create(IReadOnlyCollection<PassDTO> passes)
        {
            return new GetAllPassesResponse(passes);
        }
    }
    
}
