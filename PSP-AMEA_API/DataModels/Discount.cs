﻿namespace PSP_AMEA_API.DataModels
{
    public class Discount
    {
        public Guid Id { get; set; }
        public Boolean IsLoyalty { get; set; }
        public Guid LoyaltyTierId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string Name { get; set; }
        public int DiscountPercentage { get; set; }
        public int CashbackPercentage { get; set; }
        public int CashbackValidFor { get; set; }
        public Guid TenantId { get; set; }
    }
}
