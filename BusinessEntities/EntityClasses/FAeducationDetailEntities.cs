using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EntityClasses
{
    public class FAeducationDetailEntities
    {
        public int Id { get; set; }
        public int FAid { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Examination { get; set; }
        [Required(ErrorMessage = "Required")]
        public string University { get; set; }
        [Required(ErrorMessage = "Required")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Required")]
        public int Percentage { get; set; }
        public string Grade { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Subjects { get; set; }
    }
}
