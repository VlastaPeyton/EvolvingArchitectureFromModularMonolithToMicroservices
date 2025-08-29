

using System.Windows.Input;

namespace Contracts.Application
{
    public interface IContractsModule
    {
        Task ExecuteCommandAsync(ICommand command, CancellationToken cancellationToken); // Void vraca 
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken);  // TResult vraca tj vraca Response 
    }
}
