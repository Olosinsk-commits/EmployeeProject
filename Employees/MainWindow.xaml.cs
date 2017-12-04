using System.Windows.Navigation;
using System.Collections.ObjectModel;
namespace Employees
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        #region Data members
        private EmployeeList empList = new EmployeeList();

        //private Employee employee;
        #endregion
        //public ObservableCollection<Employee> List { get; set; }

        public static EmployeeList GetList { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // Catch closing event to save changes
            this.Closing += MainWindow_Closing;

            GetList = new EmployeeList();

            // Create Details page and navigate to page
            this.NavigationService.Navigate(new CompHome(empList));
 
        }

        private void MainWindow_Closing(object sender,
            System.ComponentModel.CancelEventArgs e)
        {
            empList.SaveEmployeeList();
        }
    }
}
