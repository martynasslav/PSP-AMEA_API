using System.ComponentModel.DataAnnotations;

namespace PSP_AMEA_API.Repository
{
    public class UpdateUserDto {
        
        [Required]
        public string Username { get; set; } = "Username";
        [Required]
        public string Password { get; set; } = "Password";
    }
}
