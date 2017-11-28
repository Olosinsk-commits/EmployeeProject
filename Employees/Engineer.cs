using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    [Serializable]
    public class Engineer : Employee
    {
        public DegreeName HighestDegree { get; set; } = DegreeName.BS;

        #region constructors 
        public Engineer() { }

        public Engineer(string firstName, string lastName, DateTime age,
                       float currPay, string ssn, DegreeName degree)
          : base(firstName, lastName, age, currPay, ssn)
        {
            // This property is defined by the Engineer class.
            HighestDegree = degree;
        }
        #endregion
        public override string Role { get { return base.Role; } }

        private static string prop1Name = "Degree:";

        private static object prop1DefaultValue = DegreeName.BS;

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
            value = HighestDegree.ToString();
        }
    }
}
