using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EntityClasses
{
    public class DistrictInfoEntities
    {
        public int DistID { get; set; }
        [Required(ErrorMessage = "Required")]
        public int StateID { get; set; }
        [Required(ErrorMessage = "Required")]
        public string DistrictCode { get; set; }
        [Required(ErrorMessage = "Required")]
        public string DistrictName { get; set; }
    }
}
