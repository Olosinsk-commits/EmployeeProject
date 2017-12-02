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

            if (data is Employee)
            {
                Employee emp = (Employee)data;
                empl = emp;
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
    }
}

