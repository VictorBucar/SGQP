using System.ComponentModel.DataAnnotations;

namespace MapperViewModels.ViewModels
{
    public class LoginInputViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
