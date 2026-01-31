using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FINALPROJECT_OOP_ALUM.Commands;

namespace FINALPROJECT_OOP_ALUM.Models
{
    public class Customer: NotifyPropertyChanged
    {
        private string? _customerId;
        private string? _customerName;
        private string? _customerContactNumber;
        public string? CustomerID
        {
            get { return _customerId; }
            set 
            { 
                _customerId = value;
                OnPropertyChanged(nameof(CustomerID));  
            }
        }
        public string? CustomerName
        {
            get { return _customerName; }
            set
            {
                _customerName = value;
                OnPropertyChanged(nameof(CustomerName));
            }
        }
        public string? CustomerContactNumber
        {
            get { return _customerContactNumber; }
            set
            {
                _customerContactNumber = value;
                OnPropertyChanged(nameof(CustomerContactNumber));
            }
        }

        public Customer() { }
        public Customer(string customerID, string? customerName, string customerContactNumber)
        {
            CustomerID = customerID;
            CustomerName = customerName;
            CustomerContactNumber = customerContactNumber;

        }

    }
}
