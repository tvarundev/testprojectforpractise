using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EntityClasses
{
    public class FarmerCropMappingEntities
    {
        public int id { get; set; }
        public int farmerId { get; set; }
        public int? cropId { get; set; }
        public int cropYear { get; set; }

        public int? acre { get; set; }
        public bool isCurrentYear { get; set; }
        public bool isActive { get; set; }

        public  CropInfoEntities CropInfoEntities { get; set; }
        public  FarmerDetailEntities FarmerDetailEntities { get; set; }
        public List<CropInfoEntities> cropList { get; set; }
    }
}
