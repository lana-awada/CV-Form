using System.ComponentModel.DataAnnotations;

namespace homework5_CV.Models.User
{
    public class DataModelUser
    {
        [Key]
        public int IdUser { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public string Role { get; set; } = "User";

    }
}
