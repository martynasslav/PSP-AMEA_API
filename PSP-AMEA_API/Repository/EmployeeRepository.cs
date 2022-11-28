using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> employees = new()
        {
            new Employee() { FirstName = "Karolis", LastName = "Karolaitis", Email = "karolis@gmail.com", Id = Guid.NewGuid() },
            new Employee() { FirstName = "Jonas", LastName = "Jonaitis", Email = "jonas@gmail.com", Id = Guid.NewGuid() },
            new Employee() { FirstName = "Petras", LastName = "Petraitis", Email = "petras@gmail.com", Id = Guid.NewGuid() }
        };

        public IEnumerable<Employee> GetEmployees()
        {
            return employees;
        }

        public Employee GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(employee => employee.Id == id);
        }

        public void CreateEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            var index = employees.FindIndex(existingEmployee => existingEmployee.Id == employee.Id);
            employees[index] = employee;
        }

        public void DeleteEmployee(Guid id)
        {
            var index = employees.FindIndex(existingEmployee => existingEmployee.Id == id);
            employees.RemoveAt(index);
        }
    }
}
