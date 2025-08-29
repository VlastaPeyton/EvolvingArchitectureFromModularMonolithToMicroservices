
namespace Common.Domain
{       
    // Znam iz EShopMicroservices, ali tamo nije ovako radjeno.
    // Osnova za kreiranje objekata koji se uporedjuju po vrednosti,a ne referenci
    public abstract class ValueObject : IEquatable<ValueObject> // IEquatable zbog poredjenja 
    {
        protected abstract IEnumerable<object> GetEqualityComponents(); // Polja izvedene klase koja se koriste za poredjenje vrednosti

        // Mora zbog interface
        public bool Equals(ValueObject? other)
        {
            return other is not null && GetType() == other.GetType() && IsSequenceEqual(other);
        }

        // Mora zbog interface
        public override bool Equals(object? obj)
        {
            return obj is ValueObject valueObject && Equals(valueObject);
        }

        // Mora zbog interface
        public override int GetHashCode()
        {   
            // Dva value object, jednaka po vrednosti polja, imace isti hash code
            return GetEqualityComponents().Aggregate(default(int), (current, obj) => HashCode.Combine(current, obj.GetHashCode()));
        }

        public static bool operator ==(ValueObject left, ValueObject right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ValueObject left, ValueObject right) {
            return !left.Equals(right);
        }

        // Da li su jednake vrednosti polja 2 value objekta
        private bool IsSequenceEqual(ValueObject other)
        {
            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }
    

    }
}
