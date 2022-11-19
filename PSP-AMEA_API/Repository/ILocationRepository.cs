using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;

namespace PSP_AMEA_API.Repository
{
    public interface ILocationRepository
    {
        Location CreateLocation(CreateLocationDto dto);
        void UpdateLocation(Location location);
        void DeleteLocation(Location location);
        IEnumerable<Location> GetAllLocations();
        Location GetLocationById(Guid id);
    }
}
