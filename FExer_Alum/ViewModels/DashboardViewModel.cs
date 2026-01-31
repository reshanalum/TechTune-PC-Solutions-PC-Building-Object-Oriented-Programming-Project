using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Input;
using FINALPROJECT_OOP_ALUM.Commands;
using System.Runtime.CompilerServices;
using FINALPROJECT_OOP_ALUM.Models;
using FINALPROJECT_OOP_ALUM.ViewModels;
using FINALPROJECT_OOP_ALUM.Views;
using FontAwesome;
using FontAwesome.WPF;

namespace FINALPROJECT_OOP_ALUM.ViewModels
{
    public class DashboardViewModel: NotifyPropertyChanged
    {
        public ICommand ShowHomeCommand { get; set; }
        public ICommand ShowInventoryCommand {  get; set; }
        public ICommand ShowPCBuildCommand { get; set; }
        public ICommand ShowCustomerCommand { get; set; }
        public ICommand ShowRepairCommand {  get; set; }
        public ICommand ShowLoginCommand { get; set; }

        public ICommand ShowTransactionCommand { get; set; }

        private NotifyPropertyChanged _currentView;
        private string _caption;

        public NotifyPropertyChanged CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public string Caption
        {
            get { return _caption; }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public DashboardViewModel() 
        {

            ShowPCBuildCommand = new RelayCommand(ExecuteShowPCBuildCommand);
            ShowInventoryCommand = new RelayCommand(ExecuteShowInventoryCommand);
            ShowCustomerCommand = new RelayCommand(ExecuteShowCustomerCommand);
            ShowRepairCommand = new RelayCommand(ExecuteShowRepairCommand);
            ShowHomeCommand = new RelayCommand(ExecuteShowHomeCommand);

        }

        private void ExecuteShowInventoryCommand(object obj)
        {
            CurrentView = new InventoryManagementViewModel();
            Caption = "Inventory";
        }

        private void ExecuteShowHomeCommand(object obj)
        {
            CurrentView = null ;
        }

        private void ExecuteShowRepairCommand(object obj)
        {
            CurrentView = new RepairServiceManagementViewModel();
            Caption = "Repair Management";
        }

        private void ExecuteShowCustomerCommand(object obj)
        {
            CurrentView = new CustomersViewModel();
            Caption = "Customer";
        }

        private void ExecuteShowPCBuildCommand(object obj)
        {
            CurrentView = new PCBuildViewModel();
            Caption = "PC Build Configuration";
        }

    }
}
