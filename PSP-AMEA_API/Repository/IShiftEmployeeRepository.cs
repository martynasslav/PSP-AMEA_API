using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;

namespace PSP_AMEA_API.Repository
{
    public interface IShiftEmployeeRepository
    {
        void CreateShiftEmployee(ShiftEmployee shiftEmployee);
        void UpdateShiftEmployee(ShiftEmployee shiftEmployee);
        void DeleteShiftEmployee(ShiftEmployee shiftEmployee);
        IEnumerable<ShiftEmployee> GetAllShiftEmployees();
        IEnumerable<Guid> GetShiftEmployeeIdsByShiftId(Guid id);
    }
}
