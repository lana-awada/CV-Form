using System.ComponentModel.DataAnnotations;

namespace homework5_CV.Models.CV
{
    public class BindingModelEdit
    {


        [Required]
        [Display(Name = "FName: ")]
        [StringLength(20, ErrorMessage = "Max Length for name is {1}")]
        public string Fname { get; set; }

        [Required]
        [Display(Name = "LName: ")]
        [StringLength(20, ErrorMessage = "Max Length for name is {1}")]
        public string Lname { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
        [Display(Name = "BDay: ")]
        public DateTime BDay { get; set; }

        [Required(ErrorMessage = "Nationality is required.")]
        [Display(Name = "Nationality: ")]
        public string Nationality { get; set; }


        [Required(ErrorMessage = "Sex is required.")]
        [Display(Name = "Sex: ")]
        public string Sex { get; set; }

        [Display(Name = "Skills: ")]
        [Required(ErrorMessage = "Skills is required.")]
        public List<string> Skills { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

/*
        [DataType(DataType.Password)]
        [Display(Name = "Password: ")]
        [MinLength(8)]
        public string Password { get; set; }*/



        /*        [Display(Name = "Photo: ")]
                [Required(ErrorMessage = "Photo is required.")]
                public IFormFile Image { get; set; }*/



    }
}


