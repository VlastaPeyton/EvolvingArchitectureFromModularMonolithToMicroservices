using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Application.Prepare;

namespace Contracts.API.Prepare
{
    // Jer Request se mapira u Command u Endpoint rucno ovako ili pomocu AutoMaper/Mapster

    internal record PrepareContractRequest(Guid CustomerId, int CustomerAge, int CustomerHeight, DateTimeOffset PreparedAt)
    {
        public PrepareContractCommand ToCommand()
        {
            return new PrepareContractCommand(CustomerId, CustomerAge, CustomerHeight, PreparedAt);
        }
    }
}
