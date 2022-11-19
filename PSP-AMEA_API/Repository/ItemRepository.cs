using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Repository
{
	public class ItemRepository : IItemRepository
	{
		private readonly List<Item> items = new();

		public void CreateItem(Item item)
		{
			items.Add(item);
		}

		public void DeleteItem(Guid id)
		{
			items.RemoveAll(i => i.Id == id);
		}

		public Item? GetItem(Guid id)
		{
			return items.SingleOrDefault(i => i.Id == id);
		}

		public IEnumerable<Item> GetTenantItems(Guid tenantId)
		{
			return items.Where(i => i.TenantId == tenantId);
		}

		public void UpdateItem(Item item)
		{
			var idx = items.FindIndex(i => i.Id == item.Id);
			items[idx] = item;
		}
	}
}
