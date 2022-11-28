using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> customers = new()
        {
            new Customer() { FirstName = "Karolis", LastName = "Karolaitis", Email = "karolis@gmail.com", Id = Guid.NewGuid() },
            new Customer() { FirstName = "Jonas", LastName = "Jonaitis", Email = "jonas@gmail.com", Id = Guid.NewGuid() },
            new Customer() { FirstName = "Petras", LastName = "Petraitis", Email = "petras@gmail.com", Id = Guid.NewGuid() }
        };

        public IEnumerable<Customer> GetCustomers()
        {
            return customers;
        }

        public Customer GetCustomer(Guid id)
        {
            return customers.SingleOrDefault(employee => employee.Id == id);
        }

        public void CreateCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            var index = customers.FindIndex(existingEmployee => existingEmployee.Id == customer.Id);
            customers[index] = customer;
        }

        public void DeleteCustomer(Guid id)
        {
            var index = customers.FindIndex(existingEmployee => existingEmployee.Id == id);
            customers.RemoveAt(index);
        }

    }
}
