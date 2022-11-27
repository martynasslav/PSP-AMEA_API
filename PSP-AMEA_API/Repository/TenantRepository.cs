using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;
using System.Collections.Generic;

namespace PSP_AMEA_API.Repository
{
    public class TenantRepository : ITenantRepository
    {
        private readonly List<Tenant> tenants = new()
        {
            new Tenant() {Id = Guid.NewGuid(), Name = "Tenant1", ActiveFrom = DateTime.Now, ActiveTo = DateTime.Now.AddDays(10)},
            new Tenant() {Id = Guid.NewGuid(), Name = "Tenant2", ActiveFrom = DateTime.Now, ActiveTo = DateTime.Now.AddDays(20)},
            new Tenant() {Id = Guid.NewGuid(), Name = "Tenant3", ActiveFrom = DateTime.Now, ActiveTo = DateTime.Now.AddDays(30)}
        };

        public Tenant CreateTenant(CreateTenantDto dto)
        {
            var tenant = new Tenant() {Id = Guid.NewGuid(), Name = dto.Name, ActiveFrom = dto.ActiveFrom, ActiveTo = dto.ActiveTo};
            tenants.Add(tenant);
            return tenant;
        }

        public void UpdateTenant(Tenant tenant)
        {
            var id = tenants.FindIndex(t => t.Id == tenant.Id);
            tenants[id] = tenant;
        }

        public void DeleteTenant(Tenant tenant)
        {
            tenants.Remove(tenant);
        }

        public IEnumerable<Tenant> GetAllTenants(int offset, int limit)
        {
            return tenants.Skip(offset).Take(limit);
        }

        public Tenant GetTenantById(Guid id)
        {
            return tenants.Find(t => t.Id == id);
        }
    }
}
