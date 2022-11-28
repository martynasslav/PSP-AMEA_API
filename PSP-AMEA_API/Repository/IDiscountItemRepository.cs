using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;

namespace PSP_AMEA_API.Repository
{
    public interface IDiscountItemRepository
    {
        void CreateDiscountItem(DiscountItem discountItem);
        void DeleteDiscountItem(DiscountItem discountItem);
        IEnumerable<DiscountItem> GetAllDiscountItems();
        IEnumerable<Guid> GetDiscountItemIdsByDiscountId(Guid id);
    }
}
