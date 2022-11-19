﻿namespace PSP_AMEA_API.Dtos
{
    public class TenantDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "Name";
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
    }
}
