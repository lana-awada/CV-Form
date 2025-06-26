using homework5_CV.Data;
using homework5_CV.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using homework5_CV.Models.CV;
using Microsoft.AspNetCore.Authorization;


namespace homework5_CV.Pages
{
    [Authorize(Roles = "User")]
    public class CVpageModel : PageModel
    {
        [BindProperty]
        public int Randomnumber { get; set; }
        public CVViewModel cvViewModel { get; set; }

        [BindProperty]
        public BindingModel bindingModel { get; set; }

        private readonly ICVservices cvservices;

        public CVpageModel(ICVservices services)
        {
            cvservices = services;
        }

        public SelectListItem[] nationalityItems { get; } =
     {
            new SelectListItem{Text="Lebanon", Value = "Lebanon"},
            new SelectListItem{Text="Canada", Value = "Canada"},
            new SelectListItem{Text="Turkie", Value = "Turkie"},
        };// eza hene bl database msh harded code bjeboun aaber baamel func bl onget() bjeboun w b7otun hone bl list aade
          // kmn bl skills nfs l shi w bl .cshtml bjeboun ka list aaber foreach
        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPostInfo()
        {
            /* if (Randomnumber > 50)
             {
                 ModelState.AddModelError("Validation of randum  number", "Random Number should be less then 50");

             }*/
            if (Randomnumber > 100)
            {
                ModelState.AddModelError("Validation of randum  number", "Random Number should be less then 100");

            }

            if (bindingModel.n1 + bindingModel.n2 != bindingModel.sum)
            {
                ModelState.AddModelError("Validation of summation", "Sum of number 1 and number 2 should be equal to sum");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }//hyde ma betbayen l data annotation baleha
           // Console.WriteLine("Inside OnPostInfo");
            int id = await cvservices.AddCv(bindingModel);
            //TempData["CVData"] = JsonConvert.SerializeObject(bindingModel);
 // kermel eshte8el feha bl CVSummary yaane for pass data
            return RedirectToPage("/CVSummary", new { Randomnumber, id/*, x = 8 */});//betredele 2 route param laeno aam mare2la 2 route values fa lama rou7 aa cvsummary bade mare2le 2 route param 7ad l @page

            // eza7atet kmn x=8 awal tnen bye5eda route param bs l x bye5eda query string
            //eza kenet string 7ad l new yaane lzm 7ot handler

        }



        //fene aaref l view model hon w 7oto propertie  public CVViewModel {get ;set;}



    }
}
/*Pass data across one redirect	           TempData (with JSON)
Pass data across multiple pages	           Session
Small primitive values(mtl l random w id w x)	                   Route/query string */