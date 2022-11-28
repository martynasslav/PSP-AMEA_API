using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;

namespace PSP_AMEA_API.Repository
{
    public interface IShiftRepository
    {
        void CreateShift(Shift shift);
        void UpdateShift(Shift shift);
        void DeleteShift(Shift shift);
        IEnumerable<Shift> GetAllShifts();
        Shift GetShiftById(Guid id);
    }
}
