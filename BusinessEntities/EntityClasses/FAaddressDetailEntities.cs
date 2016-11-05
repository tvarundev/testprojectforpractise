using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BusinessEntities.EntityClasses
{
    public class FAaddressDetailEntities
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        public int FAdetailId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Pincode { get; set; }
        [Required(ErrorMessage = "Required")]
        public Nullable<int> StateId { get; set; }
        [Required(ErrorMessage = "Required")]
        public Nullable<int> PocketId { get; set; }
        [Required(ErrorMessage = "Required")]
        public Nullable<int> SubDistrictId { get; set; }
        [Required(ErrorMessage = "Required")]
        public Nullable<int> District { get; set; }
        [Required(ErrorMessage = "Required")]
        public Nullable<int> Village { get; set; }
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Required")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Required")]
        public string EmailId { get; set; }
        public List<DistrictInfoEntities> DistrictList { get; set; }
        public List<PocketInfoEntities> PocketList { get; set; }


        
    }
}
