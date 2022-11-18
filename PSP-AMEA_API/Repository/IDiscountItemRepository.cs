using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;

namespace PSP_AMEA_API.Repository
{
    public interface IDiscountItemRepository
    {
        DiscountItem CreateDiscountItem(DiscountItemDto dto);
        void UpdateDiscountItem(DiscountItem discountItem);
        void DeleteDiscountItem(DiscountItem discountItem);
        IEnumerable<DiscountItem> GetAllDiscountItems();
        DiscountItem GetDiscountItemByDiscountId(Guid id);
    }
}
