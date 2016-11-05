using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EntityClasses
{
    public class FAexperianceDetailEntities
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        public int FAid { get; set; }
        [Required(ErrorMessage = "Required")]
        public string OrganitionName { get; set; }
        [Required(ErrorMessage = "Required")]
        public int FromMonth { get; set; }
        [Required(ErrorMessage = "Required")]
        public int FromYear { get; set; }
        [Required(ErrorMessage = "Required")]
        public int ToMonth { get; set; }
        [Required(ErrorMessage = "Required")]
        public int ToYear { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Designation { get; set; }
        [Required(ErrorMessage = "Required")]
        public int PaymentAgencyId { get; set; }
        public Nullable<int> SalaryPerMonth { get; set; }
        public Nullable<int> SalaryPerDay { get; set; }
        public Nullable<int> DA { get; set; }
        public Nullable<int> TA { get; set; }
        public Nullable<int> Travel { get; set; }
        public Nullable<int> MobileAllowance { get; set; }
        [Required(ErrorMessage = "Required")]
        public bool IsExperience { get; set; }
        public string RecomandDealerInfo { get; set; }
        public string WorkArea { get; set; }
    
    }
}
