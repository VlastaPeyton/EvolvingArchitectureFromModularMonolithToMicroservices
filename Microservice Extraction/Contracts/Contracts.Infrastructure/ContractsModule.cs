
using Contracts.Application;
using MediatR;

namespace Contracts.Infrastructure
{   
    internal sealed class ContractsModule(IMediator mediator) : IContractsModule // IContractsModule def u Application layer, jer se tamo Interface obicno definisu u Clean architecture
    {   
        // Vraca void
        public async Task ExecuteCommandAsync(ICommand command, CancellationToken cancellationToken)
        {
            await mediator.Send(command, cancellationToken); // Automatski aktivira odgovarajuci CommandHandler za zeljeni Request (koji se mapira u command kad udje u Endpoint)
        }

        // Vraca TResult 
        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken)
        {
            return await mediator.Send(command, cancellationToken); // -||-
        }
    }
}
