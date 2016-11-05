using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EntityClasses
{
    public class PesticesEntities
    {
        public int id { get; set; }
        public string pesticesName { get; set; }
        public Nullable<int> PesticideTypeId { get; set; }

        public  FarmerPesticideTypeEntities FarmerPesticideTypeEntities { get; set; }
    }
}
