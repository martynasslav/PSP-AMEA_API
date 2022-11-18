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

        public ShiftEmployee CreateShiftEmployee(ShiftEmployeeDto dto)
        {
            var shiftEmployee = new ShiftEmployee()
            {
                ShiftId = dto.ShiftId,
                EmployeeId = dto.EmployeeId
            };

            shiftEmployees.Add(shiftEmployee);

            return shiftEmployee;
        }

        public void DeleteShiftEmployee(ShiftEmployee shiftEmployee)
        {
            shiftEmployees.Remove(shiftEmployee);
        }

        public IEnumerable<ShiftEmployee> GetAllShiftEmployees()
        {
            return shiftEmployees;
        }

        public ShiftEmployee GetShiftEmployeeByShiftId(Guid id)
        {
            return shiftEmployees.Find(se => se.ShiftId == id);
        }

        public void UpdateShiftEmployee(ShiftEmployee shiftEmployee)
        {
            var id = shiftEmployees.FindIndex(se => se.ShiftId == shiftEmployee.ShiftId);
            shiftEmployees[id] = shiftEmployee;
        }
    }
}
