using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EntityClasses
{
    public class PocketCropMappingEntities
    {
        public int id { get; set; }
        public Nullable<int> PocketId { get; set; }
        public Nullable<int> CropId { get; set; }
        public  CropInfoEntities CropInfoEntity { get; set; }

        public List<CropInfoEntities> Crops = new List<CropInfoEntities>();
    }
}
