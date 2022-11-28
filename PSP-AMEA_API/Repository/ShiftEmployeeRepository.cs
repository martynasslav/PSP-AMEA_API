using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;

namespace PSP_AMEA_API.Repository
{
    public class ShiftEmployeeRepository : IShiftEmployeeRepository
    {
        private readonly List<ShiftEmployee> shiftEmployees = new()
        {
            new ShiftEmployee()
            {
                ShiftId = Guid.NewGuid(),
                EmployeeId = Guid.NewGuid()
            }
        };

        public void CreateShiftEmployee(ShiftEmployee shiftEmployee)
        {
            shiftEmployees.Add(shiftEmployee);
        }

        public void DeleteShiftEmployee(ShiftEmployee shiftEmployee)
        {
            shiftEmployees.Remove(shiftEmployee);
        }

        public IEnumerable<ShiftEmployee> GetAllShiftEmployees()
        {
            return shiftEmployees;
        }

        public IEnumerable<Guid> GetShiftEmployeeIdsByShiftId(Guid id)
        {
            return shiftEmployees.Where(s => s.ShiftId == id).Select(s => s.EmployeeId);
        }

        public void UpdateShiftEmployee(ShiftEmployee shiftEmployee)
        {
            var id = shiftEmployees.FindIndex(se => se.ShiftId == shiftEmployee.ShiftId);
            shiftEmployees[id] = shiftEmployee;
        }
    }
}
