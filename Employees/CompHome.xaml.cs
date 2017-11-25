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

    // Engineers have degrees
    [Serializable]
    public enum DegreeName { BS, MS, PhD }
    [Serializable]
    public enum ExecTitle { CEO, CTO, CFO, VP }
    [Serializable]
    public enum ShiftName { One, Two, Three }


    


    [Serializable]
    public partial class CompHome : Page
    {
        const string filename = "Employees.dat";
        static EmployeeList empList = new EmployeeList(filename);

        public bool ddDashEnabled = false;

        public CompHome()
        {

            InitializeComponent();


            // Select the All radio button
            this.employeeTypeRadioButtons.SelectedIndex = 0;

            // Set event handler for radio button changes
            this.employeeTypeRadioButtons.SelectionChanged += new SelectionChangedEventHandler(employeeTypeRadioButtons_SelectionChanged);

            dgEmps.SelectionChanged += DgEmps_SelectionChanged;

            // Fill the Employees data grid
            dgEmps.ItemsSource = empList;
        }

        private void DgEmps_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDetails.IsEnabled = true;
            btnExpanses.IsEnabled = true;
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            // Show Employee details if one selected
            if (dgEmps.SelectedIndex >= 0)
            {
                this.NavigationService.Navigate(new CompDetails(this.dgEmps.SelectedItem));
            }
        }

        private void Expenses_Click(object sender, RoutedEventArgs e)
        {
            // Show Expenses details if button selected
            if (dgEmps.SelectedIndex >= 0)
            {
                this.NavigationService.Navigate(new CompExpenses(this.dgEmps.SelectedItem));
            }
        }



        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            // Show add employee page if "Add Employee" button selected
            if (dgEmps.SelectedIndex >= 0)
            {
                this.NavigationService.Navigate(new CompAddEmployee(this.dgEmps.SelectedItem));
            }
        }

        // Handle changes to Employee type radio buttons
        void employeeTypeRadioButtons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshEmployeeList();

        }

        // Filter Employee list according to radio button setting
        void RefreshEmployeeList()
        {
            // Apply the selection
            switch (this.employeeTypeRadioButtons.SelectedIndex)
            {
                // Managers
                case 1:
                    dgEmps.ItemsSource = (List<Employee>)empList.FindAll(obj => obj is Manager);
                    break;

                // Sales
                case 2:
                    dgEmps.ItemsSource = (List<Employee>)empList.FindAll(obj => obj is SalesPerson);
                    break;

                // Other
                case 3:
                    dgEmps.ItemsSource = (List<Employee>)empList.FindAll(obj => !(obj is Manager || obj is SalesPerson));
                    break;



                // All 
                default:
                    dgEmps.ItemsSource = empList;
                    break;
            }

            dgEmps.Items.Refresh();
        }
    }
}