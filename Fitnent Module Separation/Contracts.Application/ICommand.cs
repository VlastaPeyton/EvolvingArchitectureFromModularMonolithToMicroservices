using MediatR;

namespace Contracts.Application
{   
    public interface ICommand<out TResult> : IRequest<TResult> { } // TResult je tip koji ce CommandHandler da vrati nakon izvrsenja
    public interface ICommand : IRequest { } // Ovde CommandHandler vraca void nakon izvrsenja
}
