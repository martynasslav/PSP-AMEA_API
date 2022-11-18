using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;

namespace PSP_AMEA_API.Repository
{
    public interface IShiftTypeRepository
    {
        ShiftType CreateShiftType(CreateShiftTypeDto dto);
        void UpdateShiftType(ShiftType shiftType);
        void DeleteShiftType(ShiftType shiftType);
        IEnumerable<ShiftType> GetAllShiftTypes();
        ShiftType GetShiftTypeById(Guid id);
    }
}
