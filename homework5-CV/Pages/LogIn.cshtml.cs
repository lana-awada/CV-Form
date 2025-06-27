using homework5_CV.Data;
using homework5_CV.Models.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;


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

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Input.Email == "awadalana1@gmail.com" && Input.Password == "12345")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Input.Email),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToPage("/AllCv");
            }
            

            var user = _context.User.FirstOrDefault(u => u.Email == Input.Email);

            if (user != null && Input.Email != "awadalana1@gmail.com")
            {
                var hasher = new PasswordHasher<DataModelUser>();
                var result = hasher.VerifyHashedPassword(user, user.Password, Input.Password);

                if (result == PasswordVerificationResult.Success)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.Role, user.Role ?? "User")
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    if (user.Role == "Admin")
                        return RedirectToPage("/AllCv");

                    else if (user.Role == "User")
                        return RedirectToPage("/CVpage", new { id = user.IdUser });
                }
                else
                {
                    Message = "Invalid Password.";
                    return Page();
                }
            }

            Message = "User not found.";
            return Page();
        }
    }
}
