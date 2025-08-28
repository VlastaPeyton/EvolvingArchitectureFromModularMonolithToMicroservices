using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Application.Prepare
{
    public record PrepareContractCommand(Guid CustomerId, int CustomerAge, int CustomerHeight, DateTimeOffset PreparedAt) : ICommand<Guid>;
}
