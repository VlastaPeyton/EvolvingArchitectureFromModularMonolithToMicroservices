using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.API.ErrorHandling
{   
    // Ovo mi vise ne treba ali neka ga
    public sealed class ResourceNotFoundException(Guid id) : InvalidOperationException($"Resource with {id} not found");
}
