using FINALPROJECT_OOP_ALUM.Commands;
using FINALPROJECT_OOP_ALUM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;

namespace FINALPROJECT_OOP_ALUM.ViewModels
{
    public class AddTicketViewModel : NotifyPropertyChanged
    {
        public ICommand AddTicketCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public ObservableCollection<Customer> CustomerList { get; set; } = new ObservableCollection<Customer>();

        private string? _ticketID;
        private Status _ticketStatus;
        private StatusSpecification _ticketStatusSpec;
        private Diagnosis _ticketDiagnosis;
        private string? _ticketDescription;
        private DateTime? _ticketStartDate;
        private double _ticketRepairCost;
        private Customer _selectedCustomer;

        public string? TicketID
        {
            get { return _ticketID; }
            set { _ticketID = value; }
        }

        public Status TicketStatus
        {
            get { return _ticketStatus; }
            set { _ticketStatus = value; }
        }

        public StatusSpecification TicketStatusSpec
        {
            get { return _ticketStatusSpec; }
            set { _ticketStatusSpec = value; }
        }

        public Diagnosis TicketDiagnosis
        {
            get { return _ticketDiagnosis; }
            set { _ticketDiagnosis = value; }
        }

        public string? TicketDescription
        {
            get { return _ticketDescription; }
            set { _ticketDescription = value; }
        }

        public DateTime? TicketStartDate
        {
            get { return _ticketStartDate; }
            set { _ticketStartDate = value; }
        }

        public double TicketRepairCost
        {
            get { return _ticketRepairCost; }
            set { _ticketRepairCost = value; }
        }

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged("SelectedCustomer");
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

        public IEnumerable<Diagnosis> DiagnosisOptions
        {
            get { return Enum.GetValues(typeof(Diagnosis)).Cast<Diagnosis>(); }
        }

        private string GenerateTicketID()
        {
            Random random = new Random();
            return random.Next(1000000, 10000000).ToString();
        }

        public AddTicketViewModel()
        {
            CustomerList = CustomerManagement.GetCustomers();
            AddTicketCommand = new RelayCommand(AddTicket, CanAddTicket);
            CancelCommand = new RelayCommand(Cancel, CanCancel);

            TicketID = GenerateTicketID();
        }

        private void AddTicket(object obj)
        {
            RepairTicket newRepairTicket = new RepairTicket(this.TicketID, this.SelectedCustomer, this.TicketDescription, this.TicketDiagnosis, this.TicketRepairCost, this.TicketStatusSpec, this.TicketStatus, this.TicketStartDate, null);
            RepairTicketManagement.AddRepairTicket(newRepairTicket);

            string message = $"The ticket with the ID: {TicketID} has been added to the database ";
            string caption = "Information";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBox.Show(message, caption, button, icon);

            var addTicketWindow = obj as Window;
            addTicketWindow.Close();

        }

        private void Cancel(object obj)
        {
            var addCustomerWindow = obj as Window;
            addCustomerWindow.Close();
        }

        private bool CanCancel(object obj)
        {
            return true;
        }

        private bool CanAddTicket(object obj)
        {
            return true;
        }

    }

}
