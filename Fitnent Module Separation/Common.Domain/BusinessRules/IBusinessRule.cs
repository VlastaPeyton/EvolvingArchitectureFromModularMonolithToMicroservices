using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.BusinessRules
{
    public interface IBusinessRule
    {
        bool IsMet();
        string Error { get; }
    }
}
