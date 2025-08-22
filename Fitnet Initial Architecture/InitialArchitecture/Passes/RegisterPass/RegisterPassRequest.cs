namespace InitialArchitecture.Passes.RegisterPass
{
    internal record RegisterPassRequest(Guid CustomerId, DateTimeOffset From, DateTimeOffset To);
    
}
