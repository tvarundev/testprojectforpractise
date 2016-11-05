using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EntityClasses
{
    public class FarmerLandMappingEntities
    {
        public int Id { get; set; }
        public Nullable<int> FarmerId { get; set; }
        public Nullable<int> LandTypeId { get; set; }
        public Nullable<int> OwnershipTypeId { get; set; }
        public Nullable<int> Acre { get; set; }

        public  FarmerDetailEntities FarmerDetailEntities { get; set; }
        public  FarmerLandTypeEntities FarmerLandTypeEntities { get; set; }
        public  LandOwnershipTypeEntities LandOwnershipTypeEntities { get; set; }

        public List<FarmerLandTypeEntities> landTypeList { get; set; }
        public List<LandOwnershipTypeEntities> ownershipType { get; set; }
    }
}
