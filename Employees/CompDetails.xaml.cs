using System.Windows.Controls;

namespace Employees
{
    public partial class CompDetails : Page
    {
        #region Constructors
        public CompDetails()
        {
            InitializeComponent();
        }
        string pay;
        // Custom constructor to pass Employee object
        public CompDetails(object data) : this()
        {
            // Bind context to Employee
            this.DataContext = data;

            if (data is Employee)
            {
                Employee emp = (Employee)data;
                string name1 = "";
                string value1 = "";
                string name2 = "";
                string value2 = "";

                emp.SpareDetailProp1(ref name1, ref value1);
                emp.SpareDetailProp2(ref name2, ref value2);

                SpareProp1Name.Content = name1;
                SpareProp1Value.Content = value1;
                SpareProp2Name.Content = name2;
                SpareProp2Value.Content = value2;
            }
        }
        #endregion
    }
}
