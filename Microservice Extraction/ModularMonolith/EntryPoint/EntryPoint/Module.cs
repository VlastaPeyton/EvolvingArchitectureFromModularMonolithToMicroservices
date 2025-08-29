namespace EntryPoint
{
    internal class Module(string Value)
    {
        public static readonly Module Offers = new Module("Offers");
        public static readonly Module Passes = new Module("Passes");
        public static readonly Module Reports = new Module("Reports");

        public static implicit operator string(Module module) => module.Value; 
    }
}
