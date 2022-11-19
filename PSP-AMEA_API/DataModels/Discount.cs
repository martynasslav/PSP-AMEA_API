namespace PSP_AMEA_API.DataModels
{
    public enum DiscountStatus
    {
        Percentage,
        Cashback
    }

    public class Discount
    {
        public Guid Id { get; set; }
        public Boolean IsLoyalty { get; set; }
        public Guid LoyaltyTierId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string Name { get; set; } = "Name";
        public DiscountStatus Measure { get; set; }
        public int Amount { get; set; }
        public int CashbackValidFor { get; set; }
        public Guid TenantId { get; set; }
    }
}
