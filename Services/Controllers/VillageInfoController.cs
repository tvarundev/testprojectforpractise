using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer.DBContext;
using DataLayer.Interfaces;
using DataLayer.Impelmentation;
using BusinessEntities.EntityClasses;
using Services.Common;

namespace Services.Controllers
{
    [RoutePrefix("api/VillageInfo")]
    public class VillageInfoController : ApiController
    {
        public List<VillageInfoEntities> GetVillageInfoBySubDistrictId(int subDistrictId)
        {
            try
            {
                IVillageInfoOperations villageInfoOperation = new VillageInfoOperations();
                List<VillageInfoEntities> villageList = MapEntities.MapIEnumerableCollection<VillageInfo, VillageInfoEntities>(villageInfoOperation.GetAllVillagesBySubDistrictId(subDistrictId)).ToList();
                return villageList;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}
