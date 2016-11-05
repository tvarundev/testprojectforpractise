using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EntityClasses
{
    public class FarmerConsumptionMappingEntities
    {
        public int Id { get; set; }
        public Nullable<int> FarmerId { get; set; }
        public Nullable<int> ConsumptionId { get; set; }
        public Nullable<int> Quantity { get; set; }

        public  FarmerConsumptionEntities FarmerConsumptionEntities { get; set; }
        public  FarmerDetailEntities FarmerDetailEntities { get; set; }
        public List<FarmerConsumptionEntities> ConsumptionList { get; set; }
    }
}
