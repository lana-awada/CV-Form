﻿using System.ComponentModel.DataAnnotations;

namespace homework5_CV.Models.CV
{
    public class CVViewModel
    {
        [Required]
        [Display(Name = "FName: ")]
        [StringLength(20, ErrorMessage = "Max Length for name is {1}")]
        public string Fname { get; set; }


        [Required]
        [Display(Name = "LName: ")]
        [StringLength(20, ErrorMessage = "Max Length for name is {1}")]
        public string Lname { get; set; }


        [DataType(DataType.Date, ErrorMessage = "Enter a valid date.")]
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
        [Display(Name = "Email: ")]//eza ma 7atet display bye5eda automaticly 
        public string Email { get; set; }


        [Compare("Email", ErrorMessage = "The email and confirmation email not the same.")]
        [Display(Name = "Confirm Email: ")]
        public string EmailComfirmation { get; set; }

        /*
                [DataType(DataType.Password)]
                [Display(Name = "Password: ")]
                [MinLength(8)]
                public string Password { get; set; }*/


        [Required]
        [StringLength(200)]
        [Display(Name = "Experience: ")]
        public string Experience { get; set; }


        public int n1 { get; set; }
        public int n2 { get; set; }
        public int sum { get; set; }


        [Display(Name = "Put Your CV here: ")]
        [Required(ErrorMessage = "Photo is required.")]
        public IFormFile Pdf { get; set; }//staamalet IFromeFile laeno aam bebaat soura men form ama bl ViewModel2 heye mabaaoute 5alsa men hon fa baamela bs string 










    }

}

