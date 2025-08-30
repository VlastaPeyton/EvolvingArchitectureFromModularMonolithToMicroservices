using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Domain.CustomId
{
    // record struct mora, jer zeli value type not reference type + da poredim by value not by reference
    public readonly record struct BindingContractId(Guid Value)
    {
        public static BindingContractId Create()
        {
            return new BindingContractId(Guid.NewGuid());
        }
    }
}
