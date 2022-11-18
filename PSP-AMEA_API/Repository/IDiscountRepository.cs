using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;

namespace PSP_AMEA_API.Repository
{
    public interface IDiscountRepository
    {
        Discount CreateDiscount(CreateDiscountDto dto);
        void UpdateDiscount(Discount discount);
        void DeleteDiscount(Discount discount);
        IEnumerable<Discount> GetAllDiscounts();
        Discount GetDiscountById(Guid id);
    }
}
