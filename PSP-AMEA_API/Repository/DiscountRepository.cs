using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;

namespace PSP_AMEA_API.Repository
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly List<Discount> discounts = new()
        {
            new Discount()
            {
                Id = Guid.NewGuid(),
                IsLoyalty = false,
                ValidFrom = DateTime.Today,
                ValidTo = DateTime.Today.AddDays(7),
                Name = "PercentageDiscount",
                DiscountPercenatge = 15,
                CashbackPercenatge = 0,
                CashbackValidFor = 0,
                TenantId = Guid.NewGuid()
            },
            new Discount()
            {
                Id = Guid.NewGuid(),
                IsLoyalty = true,
                LoyaltyTierId = Guid.NewGuid(),
                ValidFrom = DateTime.Today,
                ValidTo = DateTime.Today.AddDays(14),
                Name = "CashbackDiscount",
                DiscountPercenatge = 10,
                CashbackPercenatge = 5,
                CashbackValidFor = 5,
                TenantId = Guid.NewGuid()
            }
        };

        public void CreateDiscount(Discount discount)
        {
            discounts.Add(discount);
        }

        public void DeleteDiscount(Discount discount)
        {
            discounts.Remove(discount);
        }

        public IEnumerable<Discount> GetAllDiscounts()
        {
            return discounts;
        }

        public IEnumerable<Guid> GetDiscountIds()
        {
            return discounts.Select(d => d.Id).ToList();
        }

        public Discount GetDiscountById(Guid id)
        {
            return discounts.Find(d => d.Id == id);
        }

        public void UpdateDiscount(Discount discount)
        {
            var id = discounts.FindIndex(d => d.Id == discount.Id);
            discounts[id] = discount;
        }
    }
}