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
using FINALPROJECT_OOP_ALUM.Models;
using FINALPROJECT_OOP_ALUM.ViewModels;

namespace FINALPROJECT_OOP_ALUM.Views
{
    /// <summary>
    /// Interaction logic for RepairUserControl.xaml
    /// </summary>
    public partial class RepairUserControl : UserControl
    {
        public RepairUserControl()
        {
            InitializeComponent();
            DataContext = new RepairServiceManagementViewModel();
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //derived from ListView w/ Name = UserList
            RepairTicketList.Items.Filter = FilterMethod;
        }
        private bool FilterMethod(object obj)
        {
            var repairTicket = (RepairTicket)obj;

            string statusString = repairTicket.Status.ToString();

            return repairTicket.ID.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase) ||
                   statusString.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase) ||
                   repairTicket.Customer.CustomerName.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase);

        }

    }
}
