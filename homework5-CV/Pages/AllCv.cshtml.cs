using homework5_CV.Models.CV;
using homework5_CV.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace homework5_CV.Pages
{
    [Authorize(Roles = "Admin")]
    public class AllCvModel : PageModel 
    { 
        private readonly ICVservices cvservices;
        public AllCvModel(ICVservices services)
        {
            cvservices = services;
        }
        public List<DataModel> CVList { get; set; }

        public IActionResult OnGet()//eza 7atet async :     public async Task<IActionResult> OnGet() eza 7ot l task aatoul maa l await t7t

        { 
           CVList = cvservices.GetCVs();// hon ma fene 7ot await laeno l service GetCVs mano async law ken async fene 7ota await maa l async fo2 
           return Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await cvservices.DeleteCv(id);
            return RedirectToPage(); // for refresh the page after deletion
        }
    }
}
