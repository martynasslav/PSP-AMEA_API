﻿using PSP_AMEA_API.DataModels;
using System.ComponentModel.DataAnnotations;

namespace PSP_AMEA_API.Dtos
{

    public class CreateDiscountDto
    {
        [Required]
        public Boolean IsLoyalty { get; set; }
        [Required]
        public Guid LoyaltyTierId { get; set; }
        [Required]
        public DateTime ValidFrom { get; set; }
        [Required]
        public DateTime ValidTo { get; set; }
        [Required]
        public string Name { get; set; } = "Name";
        [Required]
        public DiscountStatus Measure { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public int CashbackValidFor { get; set; }
        [Required]
        public Guid TenantId { get; set; }
    }
}
