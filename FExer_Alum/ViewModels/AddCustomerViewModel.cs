using FINALPROJECT_OOP_ALUM.Commands;
using FINALPROJECT_OOP_ALUM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Bogus.DataSets;

namespace FINALPROJECT_OOP_ALUM.ViewModels
{
    public class AddCustomerViewModel
    {
        public ICommand AddCustomerCommand { get; set; }
        public ICommand CancelCommand { get; set; }


        private string _customerID;
        private string? _customerName;
        private string _customerContactNumber;

        public string CustomerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }

        public string? CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        public string CustomerContactNumber
        {
            get { return _customerContactNumber; }
            set { _customerContactNumber = value; }
        }

        private string GenerateCustomerID()
        {
            Random random = new Random();
            return random.Next(1000000, 10000000).ToString();
        }

        public AddCustomerViewModel()
        {
            AddCustomerCommand = new RelayCommand(AddCustomer, CanAddCustomer);
            CancelCommand = new RelayCommand(Cancel, CanCancel);

            CustomerID = GenerateCustomerID();
        }
        private void AddCustomer(object obj)
        {
            Customer newCustomer = new Customer(this.CustomerID, this.CustomerName, this.CustomerContactNumber);
            CustomerManagement.AddCustomer(newCustomer);

            string message = $"{CustomerName} has been added to the database with the ID: {CustomerID} ";
            string caption = "Information";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBox.Show(message, caption, button, icon);

            var addCustomerWindow = obj as Window;
            addCustomerWindow.Close();
        }

        private void Cancel(object obj)
        {
            var addCustomerWindow = obj as Window;
            addCustomerWindow.Close();
        }

        private bool CanAddCustomer(object obj)
        {
            return true;
        }

        private bool CanCancel(object obj)
        {
            return true;
        }
    }
}
