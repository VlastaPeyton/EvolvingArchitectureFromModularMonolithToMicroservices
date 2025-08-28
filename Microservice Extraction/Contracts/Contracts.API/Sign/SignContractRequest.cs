
using Contracts.Application.Sign;

namespace Contracts.API.Sign
{   
    // Jer Request se mapira u Command u Endpoint rucno ovao ili pomocu AutoMaper/Mapster
    internal record SignContractRequest(DateTimeOffset SignedAt)
    {
        public SignContractCommand ToCommand(Guid id)
        {
            return new SignContractCommand(id, SignedAt);
        }
    }
}
