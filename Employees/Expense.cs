using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    public enum ExpenseCategory { Conference, Lodging, Meals, Misc, Travel }

    [Serializable]
    public class Expense
    {
        #region Data members / properties
        public DateTime Date { get; set; } = DateTime.Today;
        public String Description { get; set; }
        public ExpenseCategory Category { get; set; }
        public double Amount { get; set; }
        #endregion

        #region Constructors
        public Expense() { }

        public Expense(DateTime expDate, ExpenseCategory category, string description, double amount)
        {
            Date = expDate;
            Category = category;
            Amount = amount;
            Description = description;
        }
        #endregion
    }
}
