using System.ComponentModel.DataAnnotations;

namespace SGQP.WebMVC.Models
{
    public class LoginInputViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
