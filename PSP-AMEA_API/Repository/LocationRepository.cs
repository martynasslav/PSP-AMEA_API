using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;

namespace PSP_AMEA_API.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly List<Location> locations = new()
        {
            new Location() {Id = Guid.NewGuid(), Address = "Location1", WorkingFrom = TimeOnly.MinValue, WorkingTo = TimeOnly.MaxValue},
            new Location() {Id = Guid.NewGuid(), Address = "Location2", WorkingFrom = TimeOnly.MinValue, WorkingTo = TimeOnly.MaxValue},
            new Location() {Id = Guid.NewGuid(), Address = "Location3", WorkingFrom = TimeOnly.MinValue, WorkingTo = TimeOnly.MaxValue}
        };

        public Location CreateLocation(CreateLocationDto dto)
        {
            var location = new Location() { Id = Guid.NewGuid(), TenantId = dto.TenantId, Address = dto.Address, WorkingFrom = dto.WorkingFrom, WorkingTo = dto.WorkingTo};
            locations.Add(location);
            return location;
        }

        public void UpdateLocation(Location location)
        {
            var id = locations.FindIndex(l => l.Id == location.Id);
            locations[id] = location;
        }

        public void DeleteLocation(Location location)
        {
            locations.Remove(location);
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return locations;
        }

        public Location GetLocationById(Guid id)
        {
            return locations.Find(l => l.Id == id);
        }
    }
}
