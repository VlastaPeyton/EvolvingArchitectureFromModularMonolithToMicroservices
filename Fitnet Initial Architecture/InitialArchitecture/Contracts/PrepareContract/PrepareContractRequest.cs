namespace InitialArchitecture.Contracts.PrepareContract
{   
    // Znam da je Request uvek record
    public record PrepareContractRequest(Guid CustomerId, int CustomerAge, int CustomerHeight, DateTime PreparedAt);
}
