using BusinessEntities.EntityClasses;
using Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class TestWebApiController : Controller
    {
        // GET: TestWebApi
        public ActionResult Index()
        {
            try
            {
                ServiceInputObject serviceObject = new ServiceInputObject
                {
                    baseURL = ConfigSettings.WebApiBaseAddress,
                    controllerName = "FarmerDetail",
                    parameterValue = string.Empty
                };

                //FarmerDetailEntity farmerDetailEntity = new FarmerDetailEntity();
                //farmerDetailEntity.crops = "Crop1";
                //farmerDetailEntity.dealerId = 3;
                //farmerDetailEntity.dealerName = "Dealer3";
                //farmerDetailEntity.faId = 3;
                //farmerDetailEntity.faName = "faName3";
                //farmerDetailEntity.farmerTypeId = 3;
                //farmerDetailEntity.firstName = "Hitesh";
                //farmerDetailEntity.landDry = "No Idea";
                //farmerDetailEntity.landIrrigation = "No Idea";
                //farmerDetailEntity.landOnRent = false;
                //farmerDetailEntity.landOwned = true;
                //farmerDetailEntity.lastName = "Ajudia";
                //farmerDetailEntity.middleName = "B";
                //farmerDetailEntity.mobileNumber = "8600520506";
                //farmerDetailEntity.numberOfFields = 2;
                //farmerDetailEntity.registrationDate = DateTime.Now;
                //farmerDetailEntity.saId = 3;
                //farmerDetailEntity.sourceOfIrrigation = "No Idea";

                List<FarmerDetailEntities> farmerDetail = ServiceMethods.GenerateGatRequest<List<FarmerDetailEntities>>(serviceObject);

                //FarmerDetailEntity insertedDetail = ServiceMethods.GeneratePostRequest<FarmerDetailEntity>(farmerDetailEntity, serviceObject);

                //farmerDetailEntity.id = 9;
                //FarmerDetailEntity updatedDetail = ServiceMethods.GeneratePutRequest<FarmerDetailEntity>(farmerDetailEntity, serviceObject);

                //int deletedRecord = ServiceMethods.GenerateDeleteRequest(9, serviceObject);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }
    }
}