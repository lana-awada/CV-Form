using homework5_CV.Data;
using homework5_CV.Models.CV;
using homework5_CV.Models.User;
using homework5_CV.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace homework5_CV.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICVservices cvservices;

        
        public IndexModel(ILogger<IndexModel> logger, ICVservices services)
        {
            _logger = logger;
            cvservices = services;
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

            int id = await cvservices.Adduser(Input);
            if(id == -1)
            {
                Message = "user with this email aleady exist.";
                return Page();
            }


            return RedirectToPage("/LogIn", new {id});

        }
    }
}
