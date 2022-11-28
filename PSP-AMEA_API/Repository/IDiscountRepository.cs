using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;

namespace PSP_AMEA_API.Repository
{
    public interface IDiscountRepository
    {
        void CreateDiscount(Discount discount);
        void UpdateDiscount(Discount discount);
        void DeleteDiscount(Discount discount);
        IEnumerable<Discount> GetAllDiscounts();
        IEnumerable<Guid> GetDiscountIds();
        Discount GetDiscountById(Guid id);
    }
}
