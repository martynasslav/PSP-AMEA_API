using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;

namespace PSP_AMEA_API.Repository
{
    public class DiscountItemRepository : IDiscountItemRepository
    {
        private readonly List<DiscountItem> discountItems = new()
        {
            new DiscountItem
            {
                DisountId = Guid.NewGuid(),
                ItemId = Guid.NewGuid()
            }
        };

        public void CreateDiscountItem(DiscountItem discountItem)
        {
            discountItems.Add(discountItem);
        }

        public void DeleteDiscountItem(DiscountItem discountItem)
        {
            discountItems.Remove(discountItem);
        }

        public IEnumerable<DiscountItem> GetAllDiscountItems()
        {
            return discountItems;
        }

        public IEnumerable<Guid> GetDiscountItemIdsByDiscountId(Guid id)
        {
            return discountItems.Where(d => d.DisountId == id).Select(d => d.ItemId);
        }
    }
}
