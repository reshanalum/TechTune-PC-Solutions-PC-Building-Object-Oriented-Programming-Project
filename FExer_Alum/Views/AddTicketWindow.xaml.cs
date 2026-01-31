using FINALPROJECT_OOP_ALUM.Models;
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
using System.Windows.Shapes;

namespace FINALPROJECT_OOP_ALUM.Views
{
    /// <summary>
    /// Interaction logic for AddTicketWindow.xaml
    /// </summary>
    public partial class AddTicketWindow : Window
    {
        public AddTicketWindow()
        {
            InitializeComponent();
            AddTicketViewModel addticketViewModel = new AddTicketViewModel();
            this.DataContext = addticketViewModel;
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

    }
}
