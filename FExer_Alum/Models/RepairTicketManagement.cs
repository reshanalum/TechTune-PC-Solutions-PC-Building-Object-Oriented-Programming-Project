using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FINALPROJECT_OOP_ALUM.Commands;
using FINALPROJECT_OOP_ALUM.Models;


namespace FINALPROJECT_OOP_ALUM.Models
{
    public class RepairTicketManagement
    {
        public static ObservableCollection<RepairTicket> DatabaseTickets { get; set; } = new ObservableCollection<RepairTicket>();
        public static ObservableCollection<RepairTicket> GetTickets()
        {
                if (DatabaseTickets.Count == 0)
                {
                    DatabaseTickets.Add(new RepairTicket("1234567", new Customer("1234512", "John Doe", "090909192031"), "PC not booting", Diagnosis.Hardware_matter, 3000, StatusSpecification.Received, Status.Completed,
                        new DateTime(2024, 5, 1), new DateTime(2024, 5, 3))); 

                    DatabaseTickets.Add(new RepairTicket("2345678", new Customer("1236796", "Jane Smith", "987654321"), "Software issue", Diagnosis.Software_matter, 3000, StatusSpecification.Diagnosed, Status.Ongoing,
                        new DateTime(2024, 5, 2), null)); 

                    DatabaseTickets.Add(new RepairTicket("3456789", new Customer("98765432", "Alice Johnson", "45678912313"), "Network problem", Diagnosis.Network_matter, 2000, StatusSpecification.Awaiting_parts, Status.Open,
                        new DateTime(2024, 5, 3), null)); 

                    DatabaseTickets.Add(new RepairTicket("4567890", new Customer("34587291", "Bob Brown", "32165498764"), "Data recovery needed", Diagnosis.Data_Recovery_matter, 1000, StatusSpecification.Repair_completed, Status.Completed,
                        new DateTime(2024, 5, 4), new DateTime(2024, 5, 6)));
                    
                    DatabaseTickets.Add(new RepairTicket("5678901", new Customer("1234513", "Alice Johnson", "090909192032"), "Screen flickering", Diagnosis.Hardware_matter, 2500, StatusSpecification.Received, Status.Open,
                         new DateTime(2024, 5, 5), null));

                     DatabaseTickets.Add(new RepairTicket("6789012", new Customer("1236797", "Jack Black", "987654322"), "Battery not charging", Diagnosis.Hardware_matter, 1500, StatusSpecification.Diagnosed, Status.Completed,
                    new DateTime(2024, 5, 6), new DateTime(2024, 5, 8)));

                    DatabaseTickets.Add(new RepairTicket("7890123", new Customer("98765433", "Emily Watson", "45678912314"), "Internet connectivity issue", Diagnosis.Network_matter, 1800, StatusSpecification.Awaiting_parts, Status.Ongoing,
                    new DateTime(2024, 5, 7), null));

                    DatabaseTickets.Add(new RepairTicket("8901234", new Customer("34587292", "Charlie Brown", "32165498765"), "Virus infection", Diagnosis.Software_matter, 1200, StatusSpecification.Repair_completed, Status.Completed,
                    new DateTime(2024, 5, 8), new DateTime(2024, 5, 10)));

                    DatabaseTickets.Add(new RepairTicket("9012345", new Customer("1234514", "Mary Johnson", "090909192033"), "Slow performance", Diagnosis.Performance_matter, 2000, StatusSpecification.Received, Status.Open,
                    new DateTime(2024, 5, 9), null));

                     DatabaseTickets.Add(new RepairTicket("0123456", new Customer("1236798", "Chris Evans", "987654323"), "Operating system crash", Diagnosis.Software_matter, 2800, StatusSpecification.Diagnosed, Status.Ongoing,
                    new DateTime(2024, 5, 10), null));

                    DatabaseTickets.Add(new RepairTicket("1234567", new Customer("98765434", "Emma Stone", "45678912315"), "Printer not working", Diagnosis.Peripheral_matter, 1500, StatusSpecification.Awaiting_parts, Status.Open,
                    new DateTime(2024, 5, 11), null));

                    DatabaseTickets.Add(new RepairTicket("2345678", new Customer("34587293", "Michael Johnson", "32165498766"), "Power supply failure", Diagnosis.Power_supply_matter, 2200, StatusSpecification.Repair_completed, Status.Completed,
                    new DateTime(2024, 1, 12), new DateTime(2024, 5, 14)));

                    DatabaseTickets.Add(new RepairTicket("3456789", new Customer("1234515", "Susan Miller", "090909192034"), "File recovery required", Diagnosis.Data_Recovery_matter, 1700, StatusSpecification.Received, Status.Open,
                    new DateTime(2024, 2, 13), null));

                    DatabaseTickets.Add(new RepairTicket("4567890", new Customer("1236799", "Tom Hanks", "987654324"), "Blue screen error", Diagnosis.Software_matter, 1900, StatusSpecification.Diagnosed, Status.Ongoing,
                    new DateTime(2024, 2, 14), null));

                    DatabaseTickets.Add(new RepairTicket("5678901", new Customer("98765435", "Julia Roberts", "45678912316"), "Mouse not responding", Diagnosis.Peripheral_matter, 1300, StatusSpecification.Awaiting_parts, Status.Open,
                    new DateTime(2024, 4, 15), null));

                }
                return DatabaseTickets;

        }
        public static void AddRepairTicket(RepairTicket repairTicket)
        {
            DatabaseTickets.Add(repairTicket);
        }

        public static void EditRepairTicket(RepairTicket SelectedTicket, Status status, StatusSpecification StatusSpecification, double? repairCost,DateTime? DateCompleted)
        {
            SelectedTicket.Status = status;
            SelectedTicket.StatusSpec = StatusSpecification;
            SelectedTicket.RepairCost = repairCost;
            SelectedTicket.DateCompleted = DateCompleted;
        }
    }




}
