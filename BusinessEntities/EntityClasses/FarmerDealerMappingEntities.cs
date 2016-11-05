using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EntityClasses
{
    public class FarmerDealerMappingEntities
    {
        public int Id { get; set; }
        public Nullable<int> FarmerId { get; set; }
        public Nullable<int> DealerId { get; set; }

        public  DealerInfoEntities DelerInfoEntities { get; set; }
        public  FarmerDetailEntities FarmerDetailEntities { get; set; }
    }
}
