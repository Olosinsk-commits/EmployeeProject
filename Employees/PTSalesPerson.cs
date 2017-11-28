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
        private static string prop1Name = "Sales Number:";

        private static object prop1DefaultValue = 0;

        // Add Employee spare props

        // Add Employee spare props
        public new static string SpareAddProp1Name() { return prop1Name; }
        public new static object SpareAddProp1DefaultValue() { return prop1DefaultValue; }

        public static object SpareAddProp1Convert(string obj)
        {
            string s = (string)obj;
            return s;
        }

        public override void GetSpareProp1(ref string name, ref string value)
        {
            name = prop1Name;
            value = SalesNumber.ToString();
        }
    }
}
