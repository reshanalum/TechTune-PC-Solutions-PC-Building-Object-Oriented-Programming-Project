using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using FINALPROJECT_OOP_ALUM.Commands;
using FINALPROJECT_OOP_ALUM.Views;
using FINALPROJECT_OOP_ALUM.Models;

namespace FINALPROJECT_OOP_ALUM.ViewModels
{
    public class RepairServiceManagementViewModel : NotifyPropertyChanged
    {
        public ICommand ShowEditUserCommand { get; set; }
        public ICommand ShowAddTicketWindowCommand { get; set; }
        public ICommand DeleteEntryCommand { get; set; }
        public ICommand ShowEditTicketWindowCommand { get; set; }
        public ICommand SaveChangesCommand { get; set; }

        private ObservableCollection<RepairTicket> _repairTicketList;

        private string _name;
        private string _description;
        private string _diagnosis;
        private double _repairCost;
        private RepairTicket _selectedTicket;

        public ObservableCollection<RepairTicket> RepairTicketList
        {
            get { return _repairTicketList; }
            set
            {
                _repairTicketList = value;
                OnPropertyChanged(nameof(RepairTicketList));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));

            }
        }

        public string Diagnosis
        {
            get { return _diagnosis; }
            set
            {
                _diagnosis = value;
                OnPropertyChanged(nameof(Diagnosis));

            }
        }

        public double RepairCost
        {
            get { return _repairCost; }
            set
            {
                _repairCost = value;
                OnPropertyChanged(nameof(RepairCost));
            }
        }

        public RepairTicket SelectedTicket
        {
            get { return _selectedTicket; }
            set
            {
                _selectedTicket = value;
                OnPropertyChanged(nameof(SelectedTicket));
            }
        }

        public RepairServiceManagementViewModel()
        {
            RepairTicketList = RepairTicketManagement.GetTickets();
            ShowAddTicketWindowCommand = new RelayCommand(ShowAddTicketWindow, CanShowAddTicketWindow);
            ShowEditTicketWindowCommand = new RelayCommand(ShowEditTicket, CanShowEditTicket);
        }

        private void ShowAddTicketWindow(object obj)
        {

            AddTicketWindow addTicketWindow = new AddTicketWindow();
            addTicketWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addTicketWindow.Show();
        }
        private void ShowEditTicket(object obj)
        {
            EditTicketWindow editTicketWindow = new EditTicketWindow();
            EditTicketViewModel edit = new EditTicketViewModel(SelectedTicket);
            editTicketWindow.DataContext = edit;
            editTicketWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            editTicketWindow.Show();
        }

        private bool CanShowAddTicketWindow(object obj)
        {
            return true;
        }

        private bool CanShowEditTicket(object obj)
        {
            return true;
        }

    }
}


