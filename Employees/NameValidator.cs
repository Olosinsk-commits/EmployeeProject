using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Employees
{
    [Serializable]
    public class NameValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null || (value is String && String.IsNullOrWhiteSpace((String)value)))
                return new ValidationResult(false, "value cannot be empty.");
            else
            {
                if (value.ToString().Length > 20)
                    return new ValidationResult(false, "Name cannot be more than 3 characters long.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
