using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer.Interfaces;
using DataLayer.Impelmentation;
using DataLayer.DBContext;
using BusinessEntities.EntityClasses;
using AutoMapper;
using Services.Common;
namespace Services.Controllers
{
    public class CropInfoController : ApiController
    {
        ICropInfoOperations cropInfoOperations = new CropInfoOperations();
        // GET: api/CropInfo
        public IEnumerable<CropInfoEntities> Get()
        {
            IEnumerable<CropInfo> cropInfoList = cropInfoOperations.GetAllCrops();
            IEnumerable<CropInfoEntities> cropInfoEntityList = MapEntities.MapIEnumerableCollection<CropInfo,CropInfoEntities>(cropInfoList);
            return cropInfoEntityList;
        }

        // GET: api/CropInfo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CropInfo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CropInfo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CropInfo/5
        public void Delete(int id)
        {
        }
    }
}
