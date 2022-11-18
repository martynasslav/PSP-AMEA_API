using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;

namespace PSP_AMEA_API.Repository
{
    public class ShiftTypeRepository : IShiftTypeRepository
    {
        private readonly List<ShiftType> shiftTypes = new()
        {
            new ShiftType
            {
                Id = Guid.NewGuid(),
                Name = "ShiftType1",
                TenantId= Guid.NewGuid()
            }
        };

        public ShiftType CreateShiftType(CreateShiftTypeDto dto)
        {
            var shiftType = new ShiftType
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                TenantId = dto.TenantId
            };

            shiftTypes.Add(shiftType);

            return shiftType;
        }

        public void DeleteShiftType(ShiftType shiftType)
        {
            shiftTypes.Remove(shiftType);
        }

        public IEnumerable<ShiftType> GetAllShiftTypes()
        {
            return shiftTypes;
        }

        public ShiftType GetShiftTypeById(Guid id)
        {
            return shiftTypes.Find(st => st.Id == id);
        }

        public void UpdateShiftType(ShiftType shiftType)
        {
            var id = shiftTypes.FindIndex(st => st.Id == shiftType.Id);
            shiftTypes[id] = shiftType;
        }
    }
}
