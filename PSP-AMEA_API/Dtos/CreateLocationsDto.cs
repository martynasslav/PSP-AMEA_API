﻿using System.ComponentModel.DataAnnotations;

namespace PSP_AMEA_API.Dtos
{
    public class CreateLocationsDto
    {
        [Required]
        public Guid TenantId { get; set; }
        [Required]
        public string Address { get; set; } = "Address";
        [Required]
        public TimeOnly WorkingFrom { get; set; }
        [Required]
        public TimeOnly WorkingTo { get; set; }
    }
}