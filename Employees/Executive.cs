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
    public class Executive : Manager
    {
        public ExecTitle Title { get; set; } = ExecTitle.VP;

        private static object prop1DefaultValue = 1000;
        public Executive() : base()
        {
            empBenefits = new GoldBenefitPackage();
            StockOptions = 10000;
        }
        private List<Employee> _reports = new List<Employee>();

        public Executive(string firstName, string lastName, DateTime age, float currPay,
                         string ssn, int numbOfOpts = 10000, ExecTitle title = ExecTitle.VP)
          : base(firstName, lastName, age, currPay, ssn, numbOfOpts)
        {
            // Title defined by the Executive class.
            Title = title;
            empBenefits = new GoldBenefitPackage();
        }

        public override string Role { get { return base.Role + ", " + Title; } }

        // Add Employee spare props
        public new static string SpareAddProp1Name() { return prop1Name; }

        public new static object SpareAddProp1DefaultValue() { return prop1DefaultValue; }

        public static object SpareAddProp2Convert(object obj)
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

            return "Range is 0 to 100,000";
        }

        //private static object prop2DefaultValue = " ";
        //public new static string SpareAddProp2Name() { return prop2Name; }
        //public new static object SpareAddProp2DefaultValue() { return prop2DefaultValue; }

        //public new static object SpareAddProp2Convert(object obj)
        //{
        //    if (obj is int) return obj;
        //    else if (obj is string)
        //    {
        //        string s = (string)obj;
        //        int value;

        //        if (int.TryParse(s, out value)) return value;
        //    }

        //    return -1;
        //}

        //// Return error message if there is error on else return empty or null string
        //public new static string SpareAddProp2Valid(object obj)
        //{
        //    if (obj is string)
        //    {
        //        string s = (string)obj;
        //        return String.Empty;
        //    }

        //    return "Cannot add";
        //}
        //public override void GetSpareProp2(ref string name, ref string value)
        //{
        //    name = prop2Name;
        //    value = reports();
        //}

        private static string prop1Name = "Stock Options:";
        private static string prop2Name = "Reports:";
        // Details spare prop
        public override void GetSpareProp1(ref string name, ref string value)
        {
            name = prop1Name;
            value = StockOptions.ToString();
        }

        private string reports()
        {
            string temp = "";
            foreach (Employee report in _reports)
            {
                temp += string.Format("{0}, ", report.GetName());
            }
            if (temp.Length > 0)
                return temp.Remove(temp.Length - 2);
            else
                return temp;
        }

        // Methods for adding/removing reports
        public override void AddReport(Employee newReport)
        {
            // Check for proper report to Executive
            if (newReport is Manager || newReport is SalesPerson)
            {
                _reports.Add(newReport);
            }
            else
            {
                Console.WriteLine("AddReport Error: {0} is not a Manager or SalesPerson, and cannot report to an Executive",
                                  newReport.Name);
            }
        }

        public override void RemoveReport(Employee emp)
        {
            // Remove report
            _reports.Remove(emp);
        }
    }
}
