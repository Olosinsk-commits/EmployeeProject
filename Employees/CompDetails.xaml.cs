using System.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Employees
{

    public partial class CompDetails : Page
    {
        Employee empl;

        #region Constructors
        public CompDetails()
        {
            InitializeComponent();

        }
        // Custom constructor to pass Employee object
        public CompDetails(object data) : this()
        {
            // Bind context to Employee
            this.DataContext = data;

            //Reports.ItemsSource = Report;

            if (data is Employee)

            {

                Employee emp = (Employee)data;
                empl = emp;
                string name1 = "";
                string value1 = "";
                string name2 = "";
                string value2 = "";

                emp.SpareDetailProp1(ref name1, ref value1);
                SpareProp1Name.Content = name1;
                SpareProp1Value.Content = value1;

                emp.SpareDetailProp2(ref name2, ref value2);
                SpareProp2Name.Content = name2;
                SpareProp2Combo.ItemsSource = Manager.GetReports();
                if (data is Manager)
                {
                Manager mng = (Manager)data;
                SpareProp2Value.ItemsSource = Manager.GetReports();
                }
                //SpareProp2Value.Items.Add(value2);
            }
        }
        #endregion

        // Handle give promotion button click
        private void GivePromotion_Click(object sender, RoutedEventArgs e)
        {
            empl.GivePromotion();

            //InitializeComponent();
            this.Refresh();
        }

        public void Refresh()
        {
            this.NavigationService.Navigate(new CompDetails(empl));
        }

        // Handle enable/disable of Details and Expenses buttons
        private void Button_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Check if an Employee is selected to enable Review button
            e.CanExecute = RBt.IsPressed;
        }

        // Handle Expenses button click
        private void RemoveReport_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            

            this.NavigationService.Navigate(new CompDetails(empl));
        }

        private void CommandBinding_Executed(object sender, RoutedEventArgs e)
        {
            //List<Employee> empList1;

            if (this.DataContext is Manager)
            {
                //empList1 = (List<Employee>)empList.FindAll(obj => !(obj is Executive));
            }

            else if (this.DataContext is Executive)
            {
            }
        }
    }
}

