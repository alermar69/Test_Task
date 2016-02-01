using ModelEmployees.Abstract;
using System;

namespace ModelEmployees.Entities
{
    public class TaxSalary : ITax
    {
        public decimal ApplyTax(decimal salary)
        {
            decimal result = salary - salary * 0.15M; ;

            if (salary < 10000)
            {
                result = salary - salary * 0.1M;
            }
            if (salary > 25000)
            {
                result = salary - salary * 0.25M;
            }
            
            return Math.Round(result, 2);
        }
        public decimal GetTax(decimal salary)
        {
            if (salary < 10000)
               return 10M;
            else if (salary > 25000)
                return 25M;
            return 15M;
        }
    }
}
