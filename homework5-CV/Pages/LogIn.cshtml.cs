using homework5_CV.Data;
using homework5_CV.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace homework5_CV.Pages
{
    public class LogInModel : PageModel
    {
        private readonly AppDbContext _context;

        public LogInModel(AppDbContext context)
        {
            _context = context;
        }


        [BindProperty]
        public BindingModelAddUser Input { get; set; }
        public ViewModelAddUser viewModelAddUser { get; set; }

        public string Message { get; set; }



        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
             if (Input.Email == "alisweidan1@gmail.com" && Input.Password == "12345")
                        {
                            return RedirectToPage("/AllCv");

                        }
            var user = _context.User.FirstOrDefault(u => u.Email == Input.Email );

            if (user != null)
            {
                var hasher = new PasswordHasher<DataModelUser>();
                var result = hasher.VerifyHashedPassword(user, user.Password, Input.Password);

                if (result == PasswordVerificationResult.Success)
                {
                    return RedirectToPage("/CVpage", new { id = user.IdUser });
                }


                else
                {
                    Message = "Invalid Password.";
                    return Page();
                }
                    
            }

            // If user is not found
            Message = "User not found.";
            return Page();
        }
    }
}
