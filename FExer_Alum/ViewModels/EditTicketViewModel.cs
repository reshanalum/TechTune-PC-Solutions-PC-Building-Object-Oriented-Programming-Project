using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using FINALPROJECT_OOP_ALUM.Commands;
using FINALPROJECT_OOP_ALUM.Models;

namespace FINALPROJECT_OOP_ALUM.ViewModels
{
    public class EditTicketViewModel : NotifyPropertyChanged
    {
        public ICommand SaveChangesCommand { get; set; }
        public ICommand CancelChangesCommand { get; set; }

        private RepairTicket _selectedTicket;
        public double? _newRepairCost;
        private Status _newStatus;
        private StatusSpecification _newStatusSpec;
        private DateTime? _dateCompleted;

        public RepairTicket SelectedTicket
        {
            get { return _selectedTicket; }
            set
            {
                _selectedTicket = value;
                OnPropertyChanged(nameof(SelectedTicket));
            }
        }

        public double? NewRepairCost
        {
            get { return _newRepairCost; }
            set
            {
                _newRepairCost = value;
                OnPropertyChanged(nameof(NewRepairCost));
            }
        }

        public Status NewStatus
        {
            get { return _newStatus; }
            set
            {
                _newStatus = value;
                OnPropertyChanged(nameof(NewStatus));
            }
        }

        public StatusSpecification NewStatusSpec
        {
            get { return _newStatusSpec; }
            set
            {
                _newStatusSpec = value;
                OnPropertyChanged(nameof(NewStatusSpec));
            }
        }

        public DateTime? DateCompleted
        {
            get { return _dateCompleted; }
            set
            {
                _dateCompleted = value;
                OnPropertyChanged(nameof(DateCompleted));
            }
        }

        public IEnumerable<Status> StatusOptions
        {
            get { return Enum.GetValues(typeof(Status)).Cast<Status>(); }
        }

        public IEnumerable<StatusSpecification> StatusSpecOptions
        {
            get { return Enum.GetValues(typeof(StatusSpecification)).Cast<StatusSpecification>(); }
        }

        public EditTicketViewModel(RepairTicket selectedTicket)
        {
            SelectedTicket = selectedTicket;
            NewRepairCost = selectedTicket.RepairCost;
            NewStatus = selectedTicket.Status ?? Status.Open; // since it is an enum
            NewStatusSpec = selectedTicket.StatusSpec ?? StatusSpecification.Received; // since it is an enum

            SaveChangesCommand = new RelayCommand(SaveChanges, CanSaveChanges);
            CancelChangesCommand = new RelayCommand(CancelChanges, CanCancelChanges);

        }
        private void SaveChanges(object obj)
        {
            RepairTicketManagement.EditRepairTicket(SelectedTicket, NewStatus, NewStatusSpec, NewRepairCost, DateCompleted);

            string message = $"Changes saved!";
            string caption = "Information";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBox.Show(message, caption, button, icon);

            var editRepairWin = obj as Window;
            editRepairWin.Close();
        }

        private void CancelChanges(object obj)
        {
            var editRepairWin = obj as Window;
            editRepairWin.Close();
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
