using System.ComponentModel.DataAnnotations;

namespace PSP_AMEA_API.Repository
{
    public class CreatePositionDto
    {
        [Required]
        public string Name { get; set; } = "Name";
    }
}
