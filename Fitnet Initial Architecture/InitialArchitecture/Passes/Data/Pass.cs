namespace InitialArchitecture.Passes.Data
{
    internal class Pass
    {
        public Guid Id { get; init; }
        public Guid CustomerId { get; init; }
        public DateTimeOffset From { get; init; }
        public DateTimeOffset To { get; private set; }

        // Private ctor jer samo unutar Register method mi treba
        private Pass(Guid id, Guid customerId, DateTimeOffset from, DateTimeOffset to)
        {
            Id = id;
            CustomerId = customerId;
            From = from;
            // Ova tri su {init;} i zato mogu samo unutar ctor 
            To = to; // Ovo je {private set;} i moze i ovde i u metodama ove klase
        }

        public static Pass Register(Guid customerId, DateTimeOffset from, DateTimeOffset to)
        {
            return new Pass(Guid.NewGuid(), customerId, from, to);  
        }

        public void MarkAsExpired(DateTimeOffset now)
        {
            To = now;
        }
    }
}
