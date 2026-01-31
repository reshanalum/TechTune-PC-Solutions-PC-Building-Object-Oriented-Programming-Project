using Bogus;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINALPROJECT_OOP_ALUM.Models
{
    public class CustomerManagement
    {
        public static ObservableCollection<Customer> DatabaseCustomers { get; set; } = new ObservableCollection<Customer>();
        public static ObservableCollection<Customer> GetCustomers()
        {
            if (DatabaseCustomers.Count == 0)
            {
                var faker = new Faker();
                var random = new Random();

                int numberOfCustomersToGenerate = 50;
                for (int i = 0; i < numberOfCustomersToGenerate; i++)
                {
                    string customerId = GenerateUniqueID(random);
                    string customerName = faker.Name.FullName();
                    string customerContactNumber = GenerateContactNumber(faker);

                    var customer = new Customer(customerId, customerName, customerContactNumber);
                    DatabaseCustomers.Add(customer);
                }
            }
            return DatabaseCustomers;
        }

        private static string GenerateUniqueID(Random random)
        {
            return random.Next(1000000, 9999999).ToString();
        }

        private static string GenerateContactNumber(Faker faker)
        {
            return "09" + faker.Random.Number(100000000, 999999999).ToString();
        }
        public static void AddCustomer(Customer customer)
        {
            DatabaseCustomers.Add(customer);
        }
        public static void DeleteCustomer(Customer customer)
        {
            DatabaseCustomers.Remove(customer);
        }

        public static void EditCustomer(Customer SelectedCustomer, string? customerName, string? customerContactNumber)
        {
            SelectedCustomer.CustomerName = customerName;
            SelectedCustomer.CustomerContactNumber = customerContactNumber;
        }

    }
}
