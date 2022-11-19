using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Repository
{
	public interface IItemRepository
	{
		void CreateItem(Item item);
		void UpdateItem(Item item);
		void DeleteItem(Guid id);
		IEnumerable<Item> GetTenantItems(Guid tenantId);
		Item GetItem(Guid id);
	}
}
