using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EntityClasses
{
    public class FarmerPesticesMappingEntities
    {
        public int id { get; set; }
        public Nullable<int> farmerId { get; set; }
        public Nullable<int> PesticesTyepId { get; set; }
        public Nullable<int> UnitId { get; set; }
        public string PesticeName { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<bool> isActive { get; set; }
        public  FarmerDetailEntities FarmerDetailEntities { get; set; }
        public  PesticesEntities PesticideEntities { get; set; }
        public PestiesUnitEntity PestisUnitEntities { get; set; }
        public  FarmerPesticideTypeEntities FarmerPesticideTypeEntities { get; set; }

        public List<FarmerPesticideTypeEntities> pesticideTypeList = new List<FarmerPesticideTypeEntities>();
        public List<PestiesUnitEntity> pestiesUnitList = new List<PestiesUnitEntity>();
    }
}
