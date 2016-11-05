using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EntityClasses
{
    public class FarmerInputSourceMappingEntities
    {
        public int Id { get; set; }
        public Nullable<int> FarmerId { get; set; }
        public Nullable<int> InputSourceId { get; set; }
        public Nullable<int> DealerId { get; set; }
        public Nullable<int> VillageId { get; set; }

        public  DealerInfoEntities DelerInfoEntities { get; set; }
        public  FarmerDetailEntities FarmerDetailEntities { get; set; }
        public  InputSourceEntities InputSourceEntities { get; set; }
        public  VillageInfoEntities VillageInfoEntities { get; set; }

        public List<DealerDetailEntities> DelerList = new List<DealerDetailEntities>();
        public List<InputSourceEntities> InputSourceList = new List<InputSourceEntities>();
        public List<VillageInfoEntities> VillageInfoList = new List<VillageInfoEntities>();
    }
}
