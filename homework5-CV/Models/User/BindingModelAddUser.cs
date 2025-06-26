using System.ComponentModel.DataAnnotations;

namespace homework5_CV.Models.User
{
    public class BindingModelAddUser
    {
     
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
