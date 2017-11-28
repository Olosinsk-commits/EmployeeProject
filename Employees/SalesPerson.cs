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
    class SalesPerson : Employee
    {
        #region constructors 
        public SalesPerson() { }

        // As a general rule, all subclasses should explicitly call an appropriate
        // base class constructor.
        public SalesPerson(string firstName, string lastName, DateTime age,
          float currPay, string ssn, int numbOfSales)
          : base(firstName, lastName, age, currPay, ssn)
        {
            // This belongs with us!
            SalesNumber = numbOfSales;
        }
        #endregion

        public int SalesNumber { get; set; }

        // A salesperson's bonus is influenced by the number of sales.
        public override sealed void GiveBonus(float amount)
        {
            int salesBonus = 0;
            if (SalesNumber >= 0 && SalesNumber <= 100)
                salesBonus = 10;
            else
            {
                if (SalesNumber >= 101 && SalesNumber <= 200)
                    salesBonus = 15;
                else
                    salesBonus = 20;
            }
            base.GiveBonus(amount * salesBonus);
        }

        // A SalesPerson gets an extra 300 on promotion
        public override sealed void GivePromotion()
        {
            base.GivePromotion();
            GiveBonus(300);
        }

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine("Sales Number: {0:N0}", SalesNumber);
        }

        private static string prop1Name = "Sales Number:";

        private static object prop1DefaultValue =0;

        // Add Employee spare props
        public static string SpareAddProp1Name() { return prop1Name; }
        public static object SpareAddProp1DefaultValue() { return prop1DefaultValue; }

        public override object SpareAddProp1Convert(object obj)
        {
            return base.SpareAddProp1Convert(obj);
        }

        public override void GetSpareProp1(ref string name, ref string value)
        {
            name = prop1Name;
            value = SalesNumber.ToString();
        }
    }
}
