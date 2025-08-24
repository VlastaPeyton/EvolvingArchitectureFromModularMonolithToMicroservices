using Contracts.Application;
using MediatR;

namespace Contracts.Infrastructure
{   
    // CQS Command
    internal sealed class ContractsModule(ISender mediator) : IContractsModule
    {   // ICommand i IContractsModule je u Applicaiton layer
        public async Task ExecuteCommandAsync(ICommand command, CancellationToken cancellationToken)
        {
            await mediator.Send(command, cancellationToken); // Automatski aktivirace CommandHandler odgovarajuci
        }

        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken)
        {
            return await mediator.Send(command, cancellationToken); // Automatski aktivirace CommandHandler odgovarajuci
        }
    }
}
