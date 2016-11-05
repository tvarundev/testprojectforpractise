using BusinessEntities.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.PageUIValues
{
    public class FAdetailPageUIvalues
    {
        public List<FAdesignationEntities> DesignationList { get; set; }
        public List<FAdocumentTypeEntities> DocumentTypeList { get; set; }
        public List<StateInfoEntities> stateList { get; set; }
        public List<DistrictInfoEntities> DistrictList { get; set; }
        public List<FApaymentAgencyEntities> PaymentAgencyList { get; set; }
        public List<FAstatusEntities> FAstatusList { get; set; }
        public List<DealerDetailEntities> DealerList { get; set; }
        public List<CropInfoEntities> CropList { get; set; }
        public List<PocketInfoEntities> PocketList { get; set; }
        public List<VillageInfoEntities> VillageList { get; set; }
        public List<SubDistrictInfoEntities> subDistrictList { get; set; }
        public List<FAapprovedByEntities> approvedByList { get; set; }
    }
}
