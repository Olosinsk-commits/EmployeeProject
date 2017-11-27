using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Employees
{
    class SNNValidator : ValidationRule
    {

        private string _snn = @"(^\d{3}-?\d{2}-?\d{4}$|^XXX-XX-XXXX$)";
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "value cannot be empty.");
            else
            {
                if (!Regex.IsMatch(value.ToString(), _snn))
                    return new ValidationResult(false, "Please, enter 123-45-6789 OR XXX-XX-XXXX.");
            }
            return ValidationResult.ValidResult;

        }
    }
}
