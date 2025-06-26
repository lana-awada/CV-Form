using Microsoft.EntityFrameworkCore;

namespace homework5_CV.Models.CV
{
    public class DataModel
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime BDay { get; set; }
        public string Nationality { get; set; }
        public string Sex { get; set; }
        public List<string> Skills { get; set; }
        public string Email { get; set; }
       // public string Password { get; set; }
       public string Experience {  get; set; }
        public string Pdfurl { get; set; }//staamalet string msh IFormeFile laeno eza aam sayev bl db ma fene estaamel l IFormeFile bsayev bs l url tabaa l soura
    }
}
