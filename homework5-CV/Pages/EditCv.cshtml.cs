using homework5_CV.Models.CV;
using homework5_CV.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace homework5_CV.Pages
{
    public class EditCvModel : PageModel
    {
        private readonly ICVservices _services;

        public EditCvModel(ICVservices services)
        {
            _services = services;
        }

        [BindProperty]
        public BindingModelEdit editBindingModel { get; set; }
        public DataModel CV { get; set; }

        public int id { get; set; }

        public SelectListItem[] nationalityItems { get; } =
 {
            new SelectListItem{Text="Lebanon", Value = "lebanon"},
            new SelectListItem{Text="Canada", Value = "canada"},
            new SelectListItem{Text="Turkie", Value = "turkie"},
        };

        public List<string> AvailableSkills { get; set; } = new List<string> { "Java", "Python", "Asp" };


        public async Task<IActionResult> OnGetAsync(int id)
        {
            CV = await _services.GetById(id);

            if (CV == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostUpdate(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
         /*   if (cv.Image != null && cv.Image.Length > 0)
            {
                var fileName = Path.GetFileName(cv.Image.FileName);
                var filePath = Path.Combine("wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await cv.Image.CopyToAsync(stream);
                }

                // Set the file path to the CV.url property
                CV.url = "/images/" + fileName;
            }*/


            await _services.UpdateCv( id ,editBindingModel);
            return RedirectToPage("/AllCv");
        }
    }
}
