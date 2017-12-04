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
        private EmployeeList emplL;
        private float amount = 100;
        #region Constructors
        public CompDetails()
        {
            InitializeComponent();
            //empList = null;

        }
        // Custom constructor to pass Employee object
        public CompDetails(object data, EmployeeList emplLT) : this()
        {


            // Bind context to Employee
            this.DataContext = data;
            emplL = emplLT;
            amount = 100;
            //this.DataContext = list;
            //emplL = MainWindow.GetList;
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

                if (data is Manager)
                {
                    Manager mng = (Manager)data;
                    SpareProp2Combo.ItemsSource = emplL;
                    SpareProp2Value.ItemsSource = mng.GetRts;
                }
            }
        }
        #endregion


        public float Bonus
        {
            get { return amount; }
            set { amount = value; }
        }

        // Handle give promotion button click
        private void GivePromotion_Click(object sender, RoutedEventArgs e)
        {
            empl.GivePromotion();
            this.NavigationService.Navigate(new CompDetails(this.empl, this.emplL));
            //InitializeComponent();
            //this.Refresh();
        }

        

        private void Bonus_Click(object sender, RoutedEventArgs e)
        {
            empl.GiveBonus(amount);
            this.NavigationService.Navigate(new CompDetails(this.empl, this.emplL));
            //InitializeComponent();
            //this.Refresh();
        }

        public void Refresh()
        {
            this.NavigationService.Navigate(new CompDetails(empl, emplL));
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


            this.NavigationService.Navigate(new CompDetails(empl, emplL));
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

