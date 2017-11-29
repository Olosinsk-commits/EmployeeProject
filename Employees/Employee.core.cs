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
using System.Text.RegularExpressions;

namespace Employees
{

    public partial class Employee
    {
        public static int NamespaceLength = 10;

        // Field data.
        public string Name { get { return FirstName + " " + LastName; } }

        static private int empID = 1;
        private int eID;
        private float currPay;
        private DateTime empDOB;
        private string empSSN;
        DateTime today = DateTime.Now;
        protected BenefitPackage empBenefits = new BenefitPackage();
        public List<Expense> Expenses { get; set; } = new List<Expense>();

        #region Properties 
        public string FirstName { get; }
        public string LastName { get; }
        public int ID { get { return eID; } }
        public float Pay { get { return currPay; } }
        public int Age { get { return today.Year - empDOB.Year; } }
        public DateTime DateOfBirth { get { return empDOB; } }
        public string SocialSecurityNumber { get { return empSSN; } }
        public string embBenefitPackage { get { return empBenefits.ToString(); } }
        public virtual string Role { get { return GetType().ToString().Substring(10); } }
        public string GetName()
        { return Name; }
        // Expose object through a read-only property.
        public BenefitPackage Benefits
        {
            get { return empBenefits; }
        }
        #endregion Properties 
    }
}
