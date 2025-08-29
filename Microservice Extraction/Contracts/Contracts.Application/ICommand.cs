

using MediatR;

namespace Contracts.Application
{   
    // FE posalje write db Request koji se u Endpoint mapira u Command, a MediatR mora znati tip Result/Response unapred kako bi znao koji CommandHandler da pozove
    public interface ICommand<out TResult> : IRequest<TResult>{} // Kada ExecuteCommandAsync vraca TResult
    public interface ICommand : IRequest { } // Kada ExecuteCommandAsync vraca void
}
