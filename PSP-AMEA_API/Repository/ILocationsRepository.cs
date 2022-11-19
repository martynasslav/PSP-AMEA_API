using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;

namespace PSP_AMEA_API.Repository
{
    public interface ILocationsRepository
    {
        Locations CreateLocations(CreateLocationsDto dto);
        void UpdateLocations(Locations locations);
        void DeleteLocations(Locations locations);
        IEnumerable<Locations> GetAllLocations();
        Locations GetLocationById(Guid id);
    }
}
