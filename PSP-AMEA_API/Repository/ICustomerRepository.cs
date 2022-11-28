using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Repository
{
    public interface ICustomerRepository
    {
        void CreateCustomer(Customer customer);
        Customer GetCustomer(Guid id);
        IEnumerable<Customer> GetCustomers();
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Guid id);
    }
}