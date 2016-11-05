using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EntityClasses
{
    public class FAtargetDetailEntities
    {
        public int Id { get; set; }
        public Nullable<int> FAid { get; set; }
        public Nullable<int> DealerId { get; set; }
        public Nullable<int> VillageId { get; set; }

        public List<FAtargetVillageMappingEntities> TargetCropsEntityMappingList { get; set; }
    }
}
