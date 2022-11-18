using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;

namespace PSP_AMEA_API.Repository
{
    public interface IShiftRepository
    {
        Shift CreateShift(CreateShiftDto dto);
        void UpdateShift(Shift shift);
        void DeleteShift(Shift shift);
        IEnumerable<Shift> GetAllShifts();
        Shift GetShiftById(Guid id);
    }
}
