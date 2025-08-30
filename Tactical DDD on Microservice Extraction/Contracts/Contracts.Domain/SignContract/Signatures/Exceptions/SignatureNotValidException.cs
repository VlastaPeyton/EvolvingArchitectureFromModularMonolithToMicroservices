using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Domain.SignContract.Signatures.Exceptions
{
    public sealed class SignatureNotValidException(string signature) : InvalidOperationException($"Signature: '{signature}' contains invalid chars");
}
