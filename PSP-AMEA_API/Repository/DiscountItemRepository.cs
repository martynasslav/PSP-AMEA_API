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

        public DiscountItem CreateDiscountItem(DiscountItemDto dto)
        {
            var discountItem = new DiscountItem
            {
                DisountId = dto.DisountId,
                ItemId = dto.ItemId
            };

            discountItems.Add(discountItem);

            return discountItem;
        }

        public void DeleteDiscountItem(DiscountItem discountItem)
        {
            discountItems.Remove(discountItem);
        }

        public IEnumerable<DiscountItem> GetAllDiscountItems()
        {
            return discountItems;
        }

        public DiscountItem GetDiscountItemByDiscountId(Guid id)
        {
            return discountItems.Find(d => d.DisountId == id);
        }

        public void UpdateDiscountItem(DiscountItem discountItem)
        {
            var id = discountItems.FindIndex(d => d.DisountId == discountItem.DisountId);
            discountItems[id] = discountItem;
        }
    }
}
