using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EntityClasses
{
    public class PocketFertilizerMappingEntities
    {
        public int Id { get; set; }
        public Nullable<int> PocketId { get; set; }
        public Nullable<int> FertilizerId { get; set; }
        public  FertilizerInfoEntities FertilizerInfoEntity { get; set; }

        public List<FertilizerInfoEntities> Fertilizers = new List<FertilizerInfoEntities>();
    }
}
