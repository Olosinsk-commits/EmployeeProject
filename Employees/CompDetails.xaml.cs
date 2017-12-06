using System.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Collections.Specialized;
using System.Linq;

namespace Employees
{

    public partial class CompDetails : Page
    {
        Employee empl;


        private EmployeeList emplL;
        //private float amount;
        #region Constructors
        Manager mngR;



        public Employee testEmp
        { get; set; } = new PTSalesPerson("Samr", "Abbott", DateTime.Parse("8/11/1984"), 20000, "525-76-5030", 20);

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


            //SpareProp2Combo.DataContext = this;
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
                    var reports =mng.GetRts;
                    SpareProp2Value.ItemsSource = mng.GetRts;
                    //mngR.AddReport(testEmp);
                }
            }
        }
        #endregion

        public float BonusTemp
        {
            get; set;
        } = 500;
       

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


        private void Bonus_Click(object sender, RoutedEventArgs e)
        {
            empl.GiveBonus(BonusTemp);
            object obj = DataContext;
            DataContext = null;
            DataContext = obj;
        }

        public void Refresh()
        {
            this.NavigationService.Navigate(new CompDetails(empl, emplL));
        }

        // Handle enable/disable of Details and Expenses buttons
        private void Button_CanExecuteAReport(object sender, CanExecuteRoutedEventArgs e)
        {
            // Check if an Employee is selected to enable Review button
            e.CanExecute = SpareProp2Combo.SelectedIndex >= 0;
        }

        private void Button_CanExecuteRReport(object sender, CanExecuteRoutedEventArgs e)
        {
            // Check if an Employee is selected to enable Review button
            e.CanExecute = SpareProp2Value.SelectedIndex >= 0;
        }


        // Handle Expenses button click

        private void RemoveReport_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //SpareProp2Combo.Items.Remove(SpareProp2Combo.SelectedItem);
            this.NavigationService.Navigate(new CompDetails(empl, emplL));
        }

        private void ReportAdd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //SpareProp2Combo.Items.Remove(SpareProp2Combo.SelectedItem);
            this.NavigationService.Navigate(new CompDetails(empl, emplL));
        }


        private void RemoveR_Click(object sender, RoutedEventArgs e)
        {
           mngR.RemoveReport(testEmp);
            //this.NavigationService.Navigate(new CompDetails(empl, emplL));
        }

        private void CommandBinding_Executed(object sender, RoutedEventArgs e)

        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

