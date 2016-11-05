using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.EntityClasses;
namespace BusinessEntities.PageUIValues
{
    public class PocketPageUIvalues
    {
        public List<StateInfoEntities> states { get; set; }
        public List<CropInfoEntities> crops { get; set; }
        public List<FertilizerInfoEntities> fertilizers { get; set; }
        public List<PocketStatusEntities> pocketStatusList { get; set; }
    }
}
