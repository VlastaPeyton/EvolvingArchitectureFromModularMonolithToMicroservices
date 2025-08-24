using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.BusinessRules;

namespace Contracts.Domain.SignContract.BusinessRules
{
    internal sealed class ContractCanOnlyBeSignedWithin30DaysFromPreparation : IBusinessRule
    {
        private readonly DateTimeOffset _preparedAt;
        private readonly DateTimeOffset _signedAt;

        public ContractCanOnlyBeSignedWithin30DaysFromPreparation(DateTimeOffset preparedAt, DateTimeOffset signedAt)
        {
            _preparedAt = preparedAt;
            _signedAt = signedAt;
        }

        public bool IsMet()
        {
            var timeDifference = _signedAt.Date - _preparedAt.Date;

            return timeDifference <= TimeSpan.FromDays(30);
        }

        public string Error => "Contract cannot be signed because more than 30 days have passed from contract preparation";
    }
}
