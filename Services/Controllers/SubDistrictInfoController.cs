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
    [RoutePrefix("api/SubDistrictInfo")]
    public class SubDistrictInfoController : ApiController
    {
        public List<SubDistrictInfoEntities> GetSubDistrictByDistrictId(int districtId)
        {
            try
            {
                IsubDistrictInfoOperations subDistrictInfoOperations = new SubDistrictInfoOperations();
                List<SubDistrictInfoEntities> subDisrictList = MapEntities.MapIEnumerableCollection<SubDistrictInfo, SubDistrictInfoEntities>(subDistrictInfoOperations.GetSubDistrictByDistrictId(districtId)).ToList();
                return subDisrictList;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        [Route("GetAllSubDistrictList")]
        public List<SubDistrictInfoEntities> GetAllSubDistrictList()
        {
            try
            {
                IsubDistrictInfoOperations subDistrictInfoOperations = new SubDistrictInfoOperations();
                List<SubDistrictInfoEntities> subDisrictList = MapEntities.MapIEnumerableCollection<SubDistrictInfo, SubDistrictInfoEntities>(subDistrictInfoOperations.GetAllSubDistrictList()).ToList();
                return subDisrictList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
