using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BusinessEntities.EntityClasses
{
    public class PocketVillageMappingEntities
    {
        public int Id { get; set; }
        public Nullable<int> PocketId { get; set; }
        [Required(ErrorMessage = "Required")]
        public Nullable<int> SubDistrictId { get; set; }
        public String SubDistrictName { get; set; }
        [Required(ErrorMessage = "Required")]
        public Nullable<int> VillageId { get; set; }
        public string VillageName { get; set; }
        public Nullable<bool> IsActive { get; set; }

        public List<SubDistrictInfoEntities> subDistricts = new List<SubDistrictInfoEntities>();
        public List<VillageInfoEntities> villages = new List<VillageInfoEntities>();
    }
}
