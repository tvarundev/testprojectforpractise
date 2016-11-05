using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities.EntityClasses;
using DataLayer.Interfaces;
using DataLayer.Impelmentation;
using DataLayer.DBContext;
using Services.Common;
namespace Services.Controllers
{
    [RoutePrefix("api/District")]
    public class DistrictController : ApiController
    {
        public List<DistrictInfoEntities> GetDistrictOfState(int id)
        {
            try
            {
                IDistrictInfoOperations districtInfo = new DistrictInfoOperations();
                List<DistrictInfoEntities> districts = MapEntities.MapList<DistrictInfo, DistrictInfoEntities>(districtInfo.GetDistrictListByStateId(id));
                return districts;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
