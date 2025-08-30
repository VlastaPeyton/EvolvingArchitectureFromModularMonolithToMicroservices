
using Contracts.Application.Sign;

namespace Contracts.API.Sign
{   
    // Jer Request se mapira u Command u Endpoint rucno ovao ili pomocu AutoMaper/Mapster
    internal record SignContractRequest(DateTimeOffset SignedAt, string Signature)
    {
        public SignContractCommand ToCommand(Guid id)
        {
            return new SignContractCommand(id, Signature,SignedAt);
        }
    }
}
