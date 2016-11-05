using BusinessEntities.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.PageUIValues
{
    public class FarmerDetailPageUIvalues
    {
        public List<DealerDetailEntities> DealerList { get; set; }
        public List<FarmerTypeEntities> FarmerTypeList { get; set; }
        public List<CropInfoEntities> CropList { get; set; }
        public List<PocketInfoEntities> PocketList { get; set; }
        public List<IrrigationSourceEntities> irrigationSourceList { get; set; }
        public List<FarmerConsumptionEntities> farmerConsumptionlist { get; set; }

        public List<VillageInfoEntities> villageList { get; set; }
    }
}
