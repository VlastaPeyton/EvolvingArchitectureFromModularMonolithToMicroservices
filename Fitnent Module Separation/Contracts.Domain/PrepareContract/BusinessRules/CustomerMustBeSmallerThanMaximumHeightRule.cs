using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.BusinessRules;

namespace Contracts.Domain.PrepareContract.BusinessRules
{
    internal sealed class CustomerMustBeSmallerThanMaximumHeightRule : IBusinessRule
    {
        private const int MaximumHeight = 210;
        private readonly int _height;

        public CustomerMustBeSmallerThanMaximumHeightRule(int height) => _height = height;
        public bool IsMet() => _height <= MaximumHeight;

        public string Error => "Customer height must fit maximum limit for gym instruments";
    }
}
