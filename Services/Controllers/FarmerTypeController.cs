using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities.EntityClasses;
using DataLayer.DBContext;
using DataLayer.Interfaces;
using DataLayer.Impelmentation;
using Services.Common;
namespace Services.Controllers
{
    public class FarmerTypeController : ApiController
    {
        // GET: api/FarmerType
        IfarmerTypeOperations farmerTypeOperation = new FarmerTypeOperations();
        public IEnumerable<FarmerTypeEntities> Get()
        {

            IEnumerable<FarmerTypeDetail> farmerTypeDetailList = farmerTypeOperation.GetAllFarmerType();
            IEnumerable<FarmerTypeEntities> farmerTypeEntities =MapEntities.MapIEnumerableCollection<FarmerTypeDetail,FarmerTypeEntities>(farmerTypeDetailList);
            return farmerTypeEntities;
        }

        // GET: api/FarmerType/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FarmerType
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/FarmerType/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FarmerType/5
        public void Delete(int id)
        {
        }
    }
}
