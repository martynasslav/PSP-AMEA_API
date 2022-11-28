using System.ComponentModel.DataAnnotations;

namespace PSP_AMEA_API.Repository
{
    public class UpdateCustomerDto { 

        [Required]
        public string FirstName { get; set; } = "FirstName";
        [Required]
        public string LastName { get; set; } = "LastName";
        [Required]
        public string Email { get; set; } = "myEmail@mail.com";
        [Required]
        public Guid TenantId { get; set; }
}
}
