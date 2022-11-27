namespace PSP_AMEA_API.DataModels
{
    public class Discount
    {
        public Guid Id { get; set; }
        public bool IsLoyalty { get; set; }
        public Guid LoyaltyTierId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string Name { get; set; } = "Name";
        public int DiscountPercenatge { get; set; }
        public int CashbackPercenatge { get; set; }
        public int CashbackValidFor { get; set; }
        public Guid TenantId { get; set; }
    }
}
