using System.ComponentModel.DataAnnotations;

namespace PSP_AMEA_API.Repository
{
    public class CreateEmployeeDto
    {
        [Required]
        public string FirstName { get; set; } = "FirstName";
        [Required]
        public string LastName { get; set; } = "LastName";
        [Required]
        public string PersonalCode { get; set; } = "PersonalCode";
        [Required]
        public string Email { get; set; } = "myEmail@mail.com";
        [Required]
        public Guid PositionId { get; set; }
    }
}
