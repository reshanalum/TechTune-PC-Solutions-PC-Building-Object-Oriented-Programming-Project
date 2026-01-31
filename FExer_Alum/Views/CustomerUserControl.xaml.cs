using FINALPROJECT_OOP_ALUM.ViewModels;
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
using FINALPROJECT_OOP_ALUM.ViewModels;
using FINALPROJECT_OOP_ALUM.Models;
using System.Windows.Shapes;

namespace FINALPROJECT_OOP_ALUM.Views
{
    /// <summary>
    /// Interaction logic for CustomerUserControl.xaml
    /// </summary>
    public partial class CustomerUserControl : UserControl
    {
        public CustomerUserControl()
        {
            InitializeComponent();
            CustomersViewModel customerViewModel = new CustomersViewModel();
            DataContext = customerViewModel;
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //derived from ListView w/ Name = UserList
            CustomerList.Items.Filter = FilterMethod;
        }
        private bool FilterMethod(object obj)
        {
            var customer = (Customer)obj;

            return customer.CustomerName.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase) || 
                   customer.CustomerContactNumber.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase) ||
                   customer.CustomerID.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase);
        }

        private void CustomerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
