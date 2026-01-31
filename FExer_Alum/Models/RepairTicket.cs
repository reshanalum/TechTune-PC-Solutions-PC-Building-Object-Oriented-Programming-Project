using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FINALPROJECT_OOP_ALUM.Commands;

namespace FINALPROJECT_OOP_ALUM.Models
{
    public enum Status
    {
        Open,
        Ongoing,
        Completed
    }

    public enum StatusSpecification
    {
        Received,
        Diagnosed,
        Awaiting_parts,
        Repair_completed,
        Completed
    }

    public enum Diagnosis
    {
        Hardware_matter,
        Performance_matter,
        Software_matter,
        Network_matter,
        Data_Recovery_matter,
        Peripheral_matter,
        Power_supply_matter,
        Resolved
    }

    public class RepairTicket : NotifyPropertyChanged
    {
        public string _Id;
        public Customer? _customer;
        public string? _description;
        public Diagnosis? _diagnosis;
        public double? _repairCost;
        public StatusSpecification? _statusSpec;
        public Status? _status;

        public string? ID
        {
            get { return _Id; }
            set
            {
                _Id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public Customer? Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                OnPropertyChanged(nameof(Customer));
            }
        }
        public string? Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public Diagnosis? Diagnosis
        {
            get { return _diagnosis; }
            set
            {
                _diagnosis = value;
                OnPropertyChanged(nameof(Diagnosis));
            }
        }


        public double? RepairCost
        {
            get { return _repairCost; }
            set
            {
                _repairCost = value;
                OnPropertyChanged(nameof(RepairCost));
            }
        }

        public StatusSpecification? StatusSpec
        {
            get { return _statusSpec; }
            set
            {
                _statusSpec = value;
                OnPropertyChanged(nameof(StatusSpec));
            }
        }

        public Status? Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        private DateTime? _startDate;
        public DateTime? StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private DateTime? _dateCompleted;
        public DateTime? DateCompleted
        {
            get { return _dateCompleted; }
            set
            {
                _dateCompleted = value;
                OnPropertyChanged(nameof(DateCompleted));
            }
        }
        public RepairTicket(string id, Customer customer, string description, Diagnosis diagnosis, double repairCost, StatusSpecification statusSpec, Status status, 
                            DateTime? startDate, DateTime? dateCompleted )
        {
            ID = id;
            Customer = customer;
            Description = description;
            Diagnosis = diagnosis;
            RepairCost = repairCost;
            StatusSpec = statusSpec;
            Status = status;
            StartDate = startDate;
            DateCompleted = dateCompleted;

        }


    }
}
