using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;

namespace PSP_AMEA_API.Repository
{
    public interface IShiftEmployeeRepository
    {
        ShiftEmployee CreateShiftEmployee(ShiftEmployeeDto dto);
        void UpdateShiftEmployee(ShiftEmployee shiftEmployee);
        void DeleteShiftEmployee(ShiftEmployee shiftEmployee);
        IEnumerable<ShiftEmployee> GetAllShiftEmployees();
        ShiftEmployee GetShiftEmployeeByShiftId(Guid id);
    }
}
