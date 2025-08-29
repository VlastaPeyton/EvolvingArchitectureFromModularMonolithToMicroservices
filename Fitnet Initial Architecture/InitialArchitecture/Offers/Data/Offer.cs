namespace InitialArchitecture.Offers.Data
{
    internal sealed class Offer
    {
        public Guid Id { get; init; }
        public Guid CustomerId { get; init; }
        public DateTimeOffset PreparedAt { get; init; }
        public decimal Discount { get; init; }
        public DateTimeOffset OfferedFromDate {  get; init; }
        public DateTimeOffset OfferedFromtTo {  get; init; }

        // Private ctor, jer ga koristim samo u metodi 
        private Offer(Guid id, Guid customerId, DateTimeOffset preparedAt, decimal discount, DateTimeOffset offeredFromDate, DateTimeOffset offeredFromtTo)
        {
            Id = id;
            CustomerId = customerId;
            PreparedAt = preparedAt;
            Discount = discount;
            OfferedFromDate = offeredFromDate;
            OfferedFromtTo = offeredFromtTo;
        }

        public static Offer PrepareStandardPassExtension(Guid customerId, DateTimeOffset nowDate)
        {
            const decimal standardDiscount = 0.1m; // Koristim 'm' da bi compiler 0.1 tretirao kao decimal, a ne double
            
            var offer = new Offer(Guid.NewGuid(), 
                                 customerId, 
                                 nowDate,
                                 standardDiscount, 
                                 nowDate,            // OfferedFromDate
                                 nowDate.AddYears(1) // OfferedFromTo
                                 );

            return offer;
        }
    }
}
