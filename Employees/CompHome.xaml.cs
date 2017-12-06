using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Employees
{
    public partial class CompHome : Page
    {
        #region Data members
        private EmployeeList empList;
        #endregion

        #region Constructors
        public CompHome()
        {
            InitializeComponent();
        }

     

        public CompHome(EmployeeList emps) : this()
        {
            empList = emps;

            // Set event handler for Employee type radio button
            this.EmployeeTypeRadioButtons.SelectionChanged += new SelectionChangedEventHandler(EmployeeTypeRadioButtons_SelectionChanged);

            // Add a routine handling the event OnSearch
            this.searchButton_Click.SelectionChanged += SearchButton_Click_SelectionChanged;
            

            //this.txtSearch.SelectionChanged += new selectio;

            // Select the first employee type radio button
            this.EmployeeTypeRadioButtons.SelectedIndex = 0;
            RefreshEmployeeList();
        }



        #endregion

        #region Class methods / Event handlers
        // Handle enable/disable of Details and Expenses buttons
        private void Button_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Check if an Employee is selected to enable Review button
            e.CanExecute = dgEmps.SelectedIndex >= 0;
        }

        // Handle Details button click
        private void Details_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Create Details page and navigate to page
            this.NavigationService.Navigate(new CompDetails(this.dgEmps.SelectedItem, empList));
        }

        private void XSearch_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            dgEmps.Items.Refresh();
        }

        // Handle Expenses button click
        private void Expenses_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Create Expenses page and navigate to page
            CompExpenses expensesPage = new CompExpenses(this.dgEmps.SelectedItem);
            this.NavigationService.Navigate(expensesPage);
        }

        private void Remove_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Create Expenses page and navigate to page
            this.NavigationService.Navigate(new CompHome(this.empList));

        }

        // Handle Add employee button click
        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CompAddEmployee(this, empList));
        }


        // Handle Remove employee button click
        private void RemoveEmployee_Click(object sender, RoutedEventArgs e)
        {
            foreach(var row in dgEmps.SelectedItems)
            { 
            Employee empl = row as Employee;
                empList.Remove(empl);
            }

            //dgEmps.InvalidateVisual();
            dgEmps.Items.Refresh();
        }

        // Handle changes to Employee type radio buttons
        private void EmployeeTypeRadioButtons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshEmployeeList();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }


        private void SearchButton_Click_SelectionChanged(object sender, RoutedEventArgs e)
        {
            
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

        }

        // Filter Employee list according to radio button setting
        public void RefreshEmployeeList()
        {
            List<Employee> empList1;

            // Apply the selection
            switch (this.EmployeeTypeRadioButtons.SelectedIndex)
            {
                // Managers
                case 1: empList1 = (List<Employee>)empList.FindAll(obj => obj is Manager);
                    break;

                // Sales
                case 2:
                    empList1 = (List<Employee>)empList.FindAll(obj => obj is SalesPerson);
                    break;

                // Other
                case 3:
                    empList1 = (List<Employee>)empList.FindAll(obj => !(obj is Manager || obj is SalesPerson));
                    break;

                // All 
                default: empList1 = empList;
                    break;
            }

            dgEmps.ItemsSource = new ObservableCollection<Employee>(empList1);

            dgEmps.Items.Refresh();
        }



        #endregion


    }
}
