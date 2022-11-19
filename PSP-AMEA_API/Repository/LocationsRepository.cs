using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;

namespace PSP_AMEA_API.Repository
{
    public class LocationsRepository : ILocationsRepository
    {
        private readonly List<Locations> locations = new()
        {
            new Locations() {Id = Guid.NewGuid(), Address = "Location1", WorkingFrom = TimeOnly.MinValue, WorkingTo = TimeOnly.MaxValue},
            new Locations() {Id = Guid.NewGuid(), Address = "Location2", WorkingFrom = TimeOnly.MinValue, WorkingTo = TimeOnly.MaxValue},
            new Locations() {Id = Guid.NewGuid(), Address = "Location3", WorkingFrom = TimeOnly.MinValue, WorkingTo = TimeOnly.MaxValue}
        };

        public Locations CreateLocations(CreateLocationsDto dto)
        {
            var location = new Locations() { Id = Guid.NewGuid(), TenantId = dto.TenantId, Address = dto.Address, WorkingFrom = dto.WorkingFrom, WorkingTo = dto.WorkingTo};
            locations.Add(location);
            return location;
        }

        public void UpdateLocations(Locations location)
        {
            var id = locations.FindIndex(l => l.Id == location.Id);
            locations[id] = location;
        }

        public void DeleteLocations(Locations location)
        {
            locations.Remove(location);
        }

        public IEnumerable<Locations> GetAllLocations()
        {
            return locations;
        }

        public Locations GetLocationById(Guid id)
        {
            return locations.Find(l => l.Id == id);
        }
    }
}
