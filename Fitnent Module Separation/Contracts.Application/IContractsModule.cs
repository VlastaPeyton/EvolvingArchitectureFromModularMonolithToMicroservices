namespace Contracts.Application
{
    public interface IContractsModule
    {
        Task ExecuteCommandAsync(ICommand command, CancellationToken cancellationToken);
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken);
    }
}
