﻿using System;
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
using System.ComponentModel;


namespace Employees
{

    [Serializable]
    public partial class CompAddEmployee : Page
    {
        public CompAddEmployee()
        {
            InitializeComponent();
            DataContext = this;
        }


        public string PersonaName { get; set; }

        public CompAddEmployee(Object data) : this()
        {
            this.DataContext = data;

            if (data is Employee)
            {
                Employee emp = (Employee)data;
            }
            //public int Age { get; set; }
            //public string Phone { get; set; }

            //private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
            //{
            //    this.Close();
            //}

            //private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            //{
            //    e.CanExecute = !Validation.GetHasError(textBox1) && !Validation.GetHasError(textBox2) && !Validation.GetHasError(textBox3)
            //        && !String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox3.Text);
            //}
        }
    }
}