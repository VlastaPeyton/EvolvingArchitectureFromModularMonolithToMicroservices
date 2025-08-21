using InitialArchitecture.Common.BusinessRuleEngine;
using InitialArchitecture.Contracts.PrepareContract.BusinessRules;
using InitialArchitecture.Contracts.SignContract.BusinessRules;

namespace InitialArchitecture.Contracts.Data
{   
    // Entity klasa nikad se ne moze naslediti i zato cu sealed
    internal sealed class Contract
    {
        private static TimeSpan StandardDuration => TimeSpan.FromDays(365);
        // C# 9 uveo {get; init;} => can be only set in object initializer or inside constructor and cannot be changed after object is fully constructed
        public Guid Id { get; init; } 
        public Guid CustomerId { get; init; }
        public DateTimeOffset PreparedAt { get; init; }
        // DateTimeOffset is safer than DateTime, jer racuna local date and time and offset from UTC
        public DateTimeOffset? SignedAt { get; private set; }
        public DateTimeOffset? ExpiringAt { get; private set; }
        public TimeSpan Duration { get; init; }
        public bool Signed => SignedAt.HasValue; // Moze HasValue, jer SignetAt ima ? 

        private Contract(Guid id, Guid customerId, DateTimeOffset preparedAt, TimeSpan duration) // private jer ga ne koristim van ove klase tj samo u Prepare funkciji
        {
            Id = id;
            CustomerId = customerId;
            PreparedAt = preparedAt;
            Duration = duration; // StandardDuration iz Prepare metode mu se prosledi
            // SignedAt i ExpiringAt ne setujem ovde, jer oni se u praksi ne setuju prilikom kreiranja Contract, vec prilikom Prepare i Sign 
        }

        // Pripremim ugovor sa StandardDuration trajanjem od 1godine i pre nego sto musterija potpise ugovor. Zato je ova metoda static.
        public static Contract Prepare(Guid customerId, int customerAge, int customerHeight, DateTimeOffset preparedAt, bool? isPreviousContractSigned = null)
        {   
            BusinessRuleValidator.Validate(new ContractCanBePreparedOnlyForAdultRule(customerAge));
            BusinessRuleValidator.Validate(new CustomerMustBeSmallerThanMaximumHeightLimitRule(customerHeight));
            BusinessRuleValidator.Validate(new PreviousContractHasToBeSignedRule(isPreviousContractSigned)); // Ovo je glupo, jer moras nekad doci prvi put u teretanu pa da nemas ugovor prethodni

            return new Contract(Guid.NewGuid(), customerId, preparedAt, StandardDuration); 
        }

        // Nije static, jer Sign moze tek nakon sto se napravi ugovor u Prepare metodi 
        public void Sign(DateTimeOffset signedAt, DateTimeOffset dateNow)
        {
            BusinessRuleValidator.Validate(new ContractCanOnlyBeSignedWithin30DaysFromPreparation(PreparedAt, signedAt));

            SignedAt = signedAt;
            ExpiringAt = dateNow.Add(Duration);
        }
    }
}
