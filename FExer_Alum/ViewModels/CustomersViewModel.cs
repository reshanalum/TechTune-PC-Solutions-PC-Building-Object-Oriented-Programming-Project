using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FINALPROJECT_OOP_ALUM.Commands;
using FINALPROJECT_OOP_ALUM.Models;
using FINALPROJECT_OOP_ALUM.Views;

namespace FINALPROJECT_OOP_ALUM.ViewModels
{
    public class CustomersViewModel: NotifyPropertyChanged
    {

        public ICommand ShowAddCustomerWindowCommand { get; set; }
        public ICommand DeleteCustomerCommand { get; set; }
        public ICommand ShowEditCustomerWindowCommand { get; set; }

        public ObservableCollection<Customer> CustomerList { get; set; } = new ObservableCollection<Customer>();


        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged("SelectedCustomer");
            }
        }

        public CustomersViewModel()
        {
            CustomerList = CustomerManagement.GetCustomers();
            ShowAddCustomerWindowCommand = new RelayCommand(ShowAddCustomerWindow, CanShowAddCustomerWindow);
            ShowEditCustomerWindowCommand = new RelayCommand(ShowEditCustomerWindow, CanShowEditCustomerWindow);
            DeleteCustomerCommand = new RelayCommand(DeleteCustomer, CanDeleteCustomer);

        }

        private void ShowAddCustomerWindow(object obj)
        {
            AddCustomerWindow addCustomerWindow = new AddCustomerWindow();
            addCustomerWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addCustomerWindow.Show();
        }
        private void ShowEditCustomerWindow(object obj)
        {
            EditCustomerWindow editCustomerWindow = new EditCustomerWindow();
            EditCustomerViewModel edit = new EditCustomerViewModel(SelectedCustomer);
            editCustomerWindow.DataContext = edit;
            editCustomerWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            editCustomerWindow.Show();
        }

        private void DeleteCustomer(object obj)
        {
            CustomerManagement.DeleteCustomer(SelectedCustomer);
        }
        private bool CanShowAddCustomerWindow(object obj)
        {
            return true;
        }

        private bool CanShowEditCustomerWindow(object obj)
        {
            return true;
        }

        private bool CanDeleteCustomer(object obj)
        {
            return true;
        }

    }

}

