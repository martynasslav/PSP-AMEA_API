using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;

namespace PSP_AMEA_API.Repository
{
    public class ShiftRepository : IShiftRepository
    {
        public readonly List<Shift> shifts = new List<Shift>()
        {
            new Shift()
            {
                Id = Guid.NewGuid(),
                DateFrom= DateTime.Today,
                DateTo= DateTime.Today.AddDays(14),
                StartsAt = DateTime.UtcNow,
                EndsAt = DateTime.UtcNow.AddHours(6),
                Type = Guid.NewGuid(),
                TenantId= Guid.NewGuid()
            },
            new Shift()
            {
                Id = Guid.NewGuid(),
                DateFrom= DateTime.Today,
                DateTo= DateTime.Today.AddDays(20),
                StartsAt = DateTime.UtcNow,
                EndsAt = DateTime.UtcNow.AddHours(8),
                Type = Guid.NewGuid(),
                TenantId= Guid.NewGuid()
            }
        };

        public void CreateShift(Shift shift)
        {
            shifts.Add(shift);
        }

        public void DeleteShift(Shift shift)
        {
            shifts.Remove(shift);
        }

        public IEnumerable<Shift> GetAllShifts()
        {
            return shifts;
        }

        public Shift GetShiftById(Guid id)
        {
            return shifts.Find(s => s.Id == id);
        }

        public void UpdateShift(Shift shift)
        {
            var id = shifts.FindIndex(s => s.Id == shift.Id);
            shifts[id] = shift;
        }
    }
}
