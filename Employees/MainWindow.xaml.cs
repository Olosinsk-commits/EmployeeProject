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

namespace Employees
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        private static string filename="Employees.dat";
        #region Data members
        private EmployeeList empList = new EmployeeList(filename);
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            //Application.Current.Exit += Current_Exit;

            //// Catch closing event to save changes
            this.Closing += MainWindow_Closing;

            //// Create Details page and navigate to page
            this.NavigationService.Navigate(new CompHome(empList));
        }

        //private void MainWindow_Closing(object sender, ExitEventArgs e)
        //{
        //    string filename = "Employees.dat";
        //    EmployeeList.SaveEmployeesAsBinary(filename, CompHome.empList);
        //}

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            EmployeeList.SaveEmployeesAsBinary(filename, CompHome.empList);
        }
    }



    }

