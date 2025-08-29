using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports.GenerateNewPassesRegistrationPerMonthReport
{
    public record NewPassesRegistrationsPerMonthDTO(int MonthOrder, string MonthName, long RegisteredPasses);
}
