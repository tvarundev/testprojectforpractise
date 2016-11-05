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
    [RoutePrefix("api/SubDistrict")]
    public class SubDistrictController : ApiController
    {
        public List<SubDistrictInfoEntities> GetSubDistrictsOfDistrict(int id)
        {
            try
            {
                IsubDistrictInfoOperations subDistrictInfoOperations = new SubDistrictInfoOperations();
                List<SubDistrictInfoEntities> subDistricts = MapEntities.MapList<SubDistrictInfo, SubDistrictInfoEntities>(subDistrictInfoOperations.GetSubDistrictByDistrictId(id));
                return subDistricts;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
