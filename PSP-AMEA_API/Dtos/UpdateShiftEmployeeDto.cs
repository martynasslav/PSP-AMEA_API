using System.ComponentModel.DataAnnotations;

namespace PSP_AMEA_API.Dtos
{
    public class UpdateShiftEmployeeDto
    {
        [Required]
        public Guid EmployeeId { get; set; }
    }
}
