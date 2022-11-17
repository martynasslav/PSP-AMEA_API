using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Repository
{
    public interface IEmployeeRepository
    {
        void CreateEmployee(Employee employee);
        Employee GetEmployee(Guid id);
        IEnumerable<Employee> GetEmployees();
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Guid id);
    }
}