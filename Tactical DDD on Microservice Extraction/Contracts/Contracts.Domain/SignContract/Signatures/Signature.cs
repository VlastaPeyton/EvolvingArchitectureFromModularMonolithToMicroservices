

using System.Text.RegularExpressions;
using Contracts.Domain.SignContract.Signatures.Exceptions;

namespace Contracts.Domain.SignContract.Signatures
{
    public sealed partial class Signature
    {
        private static readonly Regex SignaturePattern = SignatureAllowedCharacters();
        public DateTimeOffset Date { get; }
        public string Value { get; }

        private Signature(DateTimeOffset date, string value)
        {
            Date = date;
            if (!SignaturePattern.IsMatch(value))
                throw new SignatureNotValidException(value);
            Value = value;
        }

        public static Signature From(DateTimeOffset signedAt, string signature)
        {
            return new Signature(signedAt, signature);
        }

        [GeneratedRegex(@"^[A-Za-z\s]+$")] // Dozvoljena su samo slovai razmaci. Ovo je source generator za regex.
        private static partial Regex SignatureAllowedCharacters(); 
        // Zbog source regex generator + partial => compiler ce sam da generise telo metode, bez da ga pisem ja.
    }
}
