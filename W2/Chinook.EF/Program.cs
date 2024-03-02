using System;
using System.Text;
using Chinook.EF.Model;

namespace Chinook.EF
{
    class Program
    {
        public static void Main(string[]args)
        {
            Console.WriteLine("Chinook Starting...");
            var repo = new Repository();
            bool loop = true;
            while(loop)
            {
                Console.WriteLine(@"Select an action:
                1: List All Customers
                2: Add A Customer
                0: Exit");
                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        Console.WriteLine(repo.ListAllCustomers());
                        break;
                    
                    case "2":
                        repo.AddNewCustomer();
                        break;

                    case "3":
                        repo.RemoveCustomer();
                        break;

                    case "0":
                        loop = false;
                        break;

                    default:
                        break;
                }
            }
        }
    }

    class Repository
    {
        // fields
        private readonly ChinookContext _context = new ChinookContext();
        // constructor
        public Repository()
        {}

        // methods
        public string ListAllCustomers()
        {
            var sb = new StringBuilder();
            foreach( var customer in _context.Customers)
            {
                sb.AppendLine($"{customer.CustomerId}: {customer.FirstName}");
            }
            return sb.ToString();
        }

        public void AddNewCustomer()
        {
            var newCustomer = new Customer
            {
                CustomerId = 99,
                FirstName = "Richard",
                LastName = "Hawkins",
                Email = "RH@No.com"
            };

            _context.Add(newCustomer);
            _context.SaveChanges();
        }

        public void RemoveCustomer()
        {
            var customer = (Customer)_context.Customers.Where(c => c.CustomerId == 99).First();
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

    }
}