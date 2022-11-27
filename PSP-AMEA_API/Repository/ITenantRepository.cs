using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;

namespace PSP_AMEA_API.Repository
{
    public interface ITenantRepository
    {
        Tenant CreateTenant(CreateTenantDto dto);
        void UpdateTenant(Tenant tenant);
        void DeleteTenant(Tenant tenant);
        IEnumerable<Tenant> GetAllTenants();
        Tenant GetTenantById(Guid id);
    }
}
