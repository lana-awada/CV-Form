using Azure.Core;
using homework5_CV.Data;
using homework5_CV.Models.CV;
using homework5_CV.Models.User;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Identity;


namespace homework5_CV.Services
{
    public class CVservices : ICVservices
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PasswordHasher<DataModelUser> _hasher;


        public CVservices(AppDbContext context, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _hasher = new PasswordHasher<DataModelUser>();

        }

        public async Task<int> AddCv(BindingModel request)
        {
            string url = await AddPhoto(request.Image);
            var cv = new DataModel()
            {
                Fname = request.Fname,
                Lname = request.Lname,
                BDay = request.BDay,
                Sex = request.Sex,
                Email = request.Email,
                Nationality = request.Nationality,
               // Password = request.Password,
                Skills = request.Skills,
                url = url

            };
             _context.CV.Add(cv);
             _context.SaveChanges();
            return cv.Id;
        }

        public async Task<int> Adduser(BindingModelAddUser user)
        {
            var hasher = new PasswordHasher<DataModelUser>();
            var newuser = new DataModelUser()
            {
                
                Email = user.Email,               

            };
            newuser.Password = _hasher.HashPassword(newuser, user.Password);
            _context.User.Add(newuser);
            _context.SaveChanges();
            return newuser.IdUser;
        }

        public List<DataModel> GetCVs() //kermel shi zedo l dc eno naamel table list of cvs maa button edit w delete
        {
            return _context.CV.ToList();
        }/* fene 7ota :     public async Task<List<DataModel>> GetCVsAsync()
                            {
                            return await _context.CV.ToListAsync(); // Requires: using Microsoft.EntityFrameworkCore; 
                            } eza 7atet hon async bser fene 7ota bl AllCv ma7al ma aamlt call 7ota async maa await 
                                */

        public async Task<DataModel> GetById(int id)
        {
            DataModel data = await _context.CV.FindAsync(id);
            if (data == null)
            {
                data = new DataModel() { Fname = "not found", Lname = "not found" };
            }
            return data;
        }
        public async Task<IResult> DeleteCv(int id)
        {
            {
                var cv = await _context.CV.FirstOrDefaultAsync(cv => cv.Id == id);
                if (cv is null)
                {
                    return Results.NotFound("Id does not exist");
                }
                _context.CV.Remove(cv);
                await _context.SaveChangesAsync();
                return Results.Ok("Id have been deleted.");
            }
        }

      public async Task UpdateCv(int Id,BindingModelEdit updatedCv)
        {
            var datamodel = await _context.CV.FindAsync(Id);
            if (datamodel == null)
                return;
          /*  if (updatedCv.Image != null)
            {
                datamodel.url = await AddPhoto(updatedCv.Image);
            }*/
            // Manually map values from BindingModel to the entity
            datamodel.Fname = updatedCv.Fname;
            datamodel.Lname = updatedCv.Lname;
            datamodel.Email = updatedCv.Email;
            datamodel.BDay = updatedCv.BDay;
            datamodel.Nationality = updatedCv.Nationality;
            datamodel.Sex = updatedCv.Sex;
            datamodel.Skills = updatedCv.Skills;
            //datamodel.Password = updatedCv.Password;
           // datamodel.url = updatedCv.Image.ToString();


            await _context.SaveChangesAsync();
        }



        private async Task<string> AddPhoto(IFormFile image)
        {

            // the addition of the guid is so that we don't have images with same name on the server
            // a guid is a globally unique identifier
            var guid = Guid.NewGuid();
            var localFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot", "images", $"{guid + image.FileName}");//i should create a folder wth name images in wwwroot fro saving the image
            // Upload Image to local path
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.CopyToAsync(stream);

            // we want to access the image through something like this => http://localhost:1234/images/image.jpg
            // with the written code, http://localhost:1234 would be swapped with whatever domain the server is hosted on,
            // making it ready for production
            var urlFilePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}" +
                              $"{_httpContextAccessor.HttpContext.Request.PathBase}/images/{guid + image.FileName}";
            return urlFilePath;
        }


    }
}
