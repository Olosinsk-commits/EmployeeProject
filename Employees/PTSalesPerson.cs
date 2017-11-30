using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;

namespace Employees
{
    [Serializable]
    sealed class PTSalesPerson : SalesPerson
    {
        public PTSalesPerson(string firstName, string lastName, DateTime age,
                             float currPay, string ssn, int numbOfSales)
          : base(firstName, lastName, age, currPay, ssn, numbOfSales)
        {
        }

        public PTSalesPerson(string firstName, string lastName, DateTime age,
                     float currPay, string ssn)
         : base(firstName, lastName, age, currPay, ssn)
        {
        }

        private static string prop1Name = "Sales Number:";

        private static object prop1DefaultValue = 0;

        // Add Employee spare props

        // Add Employee spare props
        public new static string SpareAddProp1Name() { return prop1Name; }
        public new static object SpareAddProp1DefaultValue() { return prop1DefaultValue; }


        public new static object SpareAddProp1Convert(object obj)
        {
            if (obj is int) return obj;
            else if (obj is string)
            {
                string s = (string)obj;
                int value;

                if (int.TryParse(s, out value)) return value;
            }

            return -1;
        }


        // Return error message if there is error on else return empty or null string
        public new static string SpareAddProp1Valid(object obj)
        {
            if (obj is string)
            {
                string s = (string)obj;
                int value;

                if (int.TryParse(s, out value) && value >= 0 && value <= 10000)
                    return String.Empty;
            }

            return "Range is 0 to 10,000";
        }

        public override void GetSpareProp1(ref string name, ref string value)
        {
            name = prop1Name;
            value = SalesNumber.ToString();
        }
    }
}
