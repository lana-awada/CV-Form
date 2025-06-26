using Microsoft.EntityFrameworkCore;
using System.IO;
using System;
using System.ComponentModel.DataAnnotations;


namespace homework5_CV.Models.CV
{
    public class ViewModel2
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime BDay { get; set; }
        public string Nationality { get; set; }
        public string Sex { get; set; }
        public List<string> Skills { get; set; }
        public string Email { get; set; }
        public string Experience { get; set; }
        public string Pdf { get; set; } /*Use string when: The image has already been uploaded.

                                                               You’re just storing or displaying the path or URL to the image.*/
        public int Randomnumber { get; set; }

    }
}
