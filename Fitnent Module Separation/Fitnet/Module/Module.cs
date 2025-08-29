namespace Fitnet.Module
{
    public record Module(string value)
    {
        internal static readonly Module Contracts = new Module("Contracts");
        internal static readonly Module Offers = new Module("Offers");
        internal static readonly Module Passes = new Module("Passes");
        internal static readonly Module Reports = new Module("Reports");

        public static implicit operator string(Module module) => module.value;

    }
}
