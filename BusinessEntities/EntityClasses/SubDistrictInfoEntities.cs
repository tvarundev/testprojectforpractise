using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EntityClasses
{
    public class SubDistrictInfoEntities
    {
        public int SubDistID { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<int> DistrictID { get; set; }
        public string VillCode { get; set; }
        public string SubDistrictName { get; set; }
        public string DistrictName { get; set; }
        public string SubDistrictNameWithDistrict
        {
            get
            {
                return SubDistrictName + " " + "||" + " " + DistrictName;
            }
        }
    }
}
