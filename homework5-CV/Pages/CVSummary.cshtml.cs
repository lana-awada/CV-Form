using homework5_CV.Models;
using homework5_CV.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
    
namespace homework5_CV.Pages
{
    public class CVSummaryModel : PageModel

    {
        private readonly ICVservices cvservices;
        [BindProperty(SupportsGet =true)]
        public int Randomnumber { get; set; }
        public CVSummaryModel(ICVservices services)
        {
            cvservices = services;
        }
        public ViewModel2 CV { get; set; }



        public async Task<IActionResult> OnGet(int id)
        {

            DataModel CVResult = await cvservices.GetById(id);

            CV = new ViewModel2
            {
                Id = CVResult.Id,
                Lname = CVResult.Lname,
                Fname = CVResult.Fname,
                BDay = CVResult.BDay,
                Nationality = CVResult.Nationality,
                Sex = CVResult.Sex,
                Email = CVResult.Email,
                Skills = CVResult.Skills,
                Imageurl = CVResult.url,

            };
            return Page();


        }
    }
}
