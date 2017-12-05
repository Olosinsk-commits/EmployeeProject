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
        //private float amount;
        #region Constructors
        Manager mngR;
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
            BonusNumber.DataContext = this;
            //amount = 100;
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
                    mngR = mng;
                    SpareProp2Combo.ItemsSource = emplL;
                    SpareProp2Value.ItemsSource = mng.GetRts;
                }
            }
        }
        #endregion


        //public float Bonus
        //{
        //    get { return amount; }
        //    set { amount = value; }
        //}
        public float BonusTemp
        {
            get; set;
        } 
       

        // Handle give promotion button click
        private void GivePromotion_Click(object sender, RoutedEventArgs e)
        {
            empl.GivePromotion();

            //InitializeComponent();
            //this.NavigationService.Navigate(new CompDetails(this.empl, this.emplL));
            object obj = DataContext;
            DataContext = null;
            DataContext = obj;

        }

        void RemoveBackEntry(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();

        }

        private void Bonus_Click(object sender, RoutedEventArgs e)
        {
            empl.GiveBonus(BonusTemp);
            object obj = DataContext;
            DataContext = null;
            DataContext = obj;

            //this.NavigationService.Navigate(new CompDetails(this.empl, this.emplL));
            //empl.Pay =Pay;
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
            //SpareProp2Combo.Items.Remove(SpareProp2Combo.SelectedItem);

            ///mngR.RemoveReport(SpareProp2Combo.SelectionBoxItem);
            this.NavigationService.Navigate(new CompDetails(empl, emplL));
        }


        private void RemoveR_Click(object sender, RoutedEventArgs e)
        {
            //SpareProp2Combo.Items.Remove(SpareProp2Combo.SelectedItem);
            this.NavigationService.Navigate(new CompDetails(this.empl, this.emplL));

            //InitializeComponent();
            //this.Refresh();
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

