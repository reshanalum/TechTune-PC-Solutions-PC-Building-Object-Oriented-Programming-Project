using FINALPROJECT_OOP_ALUM.Commands;
using FINALPROJECT_OOP_ALUM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace FINALPROJECT_OOP_ALUM.ViewModels
{
    public class EditCustomerViewModel : NotifyPropertyChanged
    {
        public ICommand SaveChangesCommand { get; set; } 
        public ICommand CancelChangesCommand { get; set; } 

        private Customer _selectedCustomer;
        public string? _newName;
        public string? _newContactNumber;

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));
            }
        }

        public string? NewName
        {
            get { return _newName; }
            set
            {
                _newName = value;
                OnPropertyChanged(nameof(NewName));
            }
        }

        public string? NewContactNumber
        {
            get { return _newContactNumber; }
            set
            {
                _newContactNumber = value;
                OnPropertyChanged(nameof(NewContactNumber));
            }
        }

        public EditCustomerViewModel(Customer selectedCustomer)
        {
            SelectedCustomer = selectedCustomer;
            NewName = SelectedCustomer.CustomerName;
            NewContactNumber = SelectedCustomer.CustomerContactNumber;

            SaveChangesCommand = new RelayCommand(SaveChanges, CanSaveChanges);
            CancelChangesCommand = new RelayCommand(CancelChanges, CanCancelChanges);
        }
        private void SaveChanges(object obj)
        {
            CustomerManagement.EditCustomer(SelectedCustomer, NewName, NewContactNumber);
            var editCustomerWin = obj as Window;
            editCustomerWin.Close();

            // Show a message box confirming the addition of the user
            string message = $"Changes saved!";
            string caption = "Information";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBox.Show(message, caption, button, icon);
        }

        private void CancelChanges(object obj)
        {
            var editComponentWindow = obj as Window;
            editComponentWindow.Close();
        }

        private bool CanSaveChanges(object obj)
        {
            return true;
        }

        private bool CanCancelChanges(object obj)
        {
            return true;
        }

    }
}
