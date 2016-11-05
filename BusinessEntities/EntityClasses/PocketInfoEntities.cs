using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BusinessEntities.EntityClasses
{
    public class PocketInfoEntities
    {
        public int PocketID { get; set; }
        [Required(ErrorMessage = "Required")]
        public string PocketName { get; set; }
        public string PocaketPotentiallity { get; set; }
        [Required(ErrorMessage = "Required")]
        public Nullable<int> StateID { get; set; }
        public string StateName { get; set; }
        [Required(ErrorMessage = "Required")]
        public Nullable<int> DistrictId { get; set; }
        public string DistrictName { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<int> PocketStatusId { get; set; }
        public PocketStatusEntities pocketStatus { get; set; }
        public List<PocketVillageMappingEntities> PocketVillageMappingList { get; set; }
        public List<PocketCropMappingEntities> PocketCropMappingList { get; set; }
        public List<PocketFertilizerMappingEntities> PocketFertilizerMappingList { get; set; }

        public List<StateInfoEntities> states = new List<StateInfoEntities>();

        public List<DistrictInfoEntities> districts = new List<DistrictInfoEntities>();

        public List<PocketStatusEntities> pocketStatusList = new List<PocketStatusEntities>();

    }
}
