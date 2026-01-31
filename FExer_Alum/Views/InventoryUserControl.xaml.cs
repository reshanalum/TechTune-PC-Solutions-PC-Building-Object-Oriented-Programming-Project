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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FINALPROJECT_OOP_ALUM.Views
{
    /// <summary>
    /// Interaction logic for InventoryUserControl.xaml
    /// </summary>
    public partial class InventoryUserControl : UserControl
    {
        public InventoryUserControl()
        {
            InitializeComponent();
            InventoryManagementViewModel inventoryManagementViewModel = new InventoryManagementViewModel();
            this.DataContext = inventoryManagementViewModel;
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //derived from ListView w/ Name = UserList
            InventoryList.Items.Filter = FilterMethod;
        }
        private bool FilterMethod(object obj)
        {
            var component = (Component)obj;

            string categoryString = component.ComponentCategory.ToString();

            //if (RecordOption1 == Name )
            return component.ComponentName.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase) || 
                   component.ComponentBrand.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase) ||
                   categoryString.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase) ||
                   component.ComponentID.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase);

        }

        private void InventoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
