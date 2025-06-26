using System.ComponentModel.DataAnnotations;

namespace homework5_CV.Models.User
{
    public class ViewModelAddUser
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
