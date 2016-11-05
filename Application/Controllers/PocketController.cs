using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities.EntityClasses;
using BusinessEntities.Enums;
using Application.Models;
using Application.Common;
using Newtonsoft.Json;
using BusinessEntities.PageUIValues;
using Application.PageDropdownClasses;
namespace Application.Controllers
{
    public class PocketController : Controller
    {
        public ActionResult PocketDetail()
        {
            ServiceInputObject serviceInputsForDocType = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "Pocket",
                methodName = "GetPocketDetailList"
            };
            List<PocketInfoEntities> pocketDetailList = new List<PocketInfoEntities>();
            pocketDetailList = ServiceMethods.GenerateGatRequest<List<PocketInfoEntities>>(serviceInputsForDocType);
            return View(pocketDetailList);
        }
        public ActionResult SelectedPocket(int id)
        {
            ServiceInputObject serviceInputsForDocType = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "Pocket",
                methodName = "GetPocketDetail",
                parameterValue=Convert.ToString(id)
            };
            PocketInfoEntities pocketDetail = new PocketInfoEntities();
            pocketDetail = ServiceMethods.GenerateGatRequest<PocketInfoEntities>(serviceInputsForDocType);

            PocketModel pocketModel = new PocketModel();
            pocketModel.pocketInfo = pocketDetail;
            pocketModel.isInDetailMode = true;
            pocketModel.ActionType = ActionTypeEnum.Select;

            return View("CreatePocket", pocketModel);
        }

        public ActionResult SelectedPocketForUpdate(int id)
        {
            ServiceInputObject serviceInputsForDocType = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "Pocket",
                methodName = "GetPocketDetailForUpdate",
                parameterValue = Convert.ToString(id)
            };
            PocketInfoEntities pocketDetail = new PocketInfoEntities();
            pocketDetail = ServiceMethods.GenerateGatRequest<PocketInfoEntities>(serviceInputsForDocType);

            PocketModel pocketModel = new PocketModel();
            pocketModel.pocketInfo = pocketDetail;
            pocketModel.isInDetailMode = false;
            pocketModel.ActionType = ActionTypeEnum.Update;

            return View("CreatePocket", pocketModel);
        }

        public ActionResult DeletePocket(int id)
        {
            ServiceInputObject serviceInputsForDocType = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "Pocket",
                methodName = "DeletePocketDetail",
                parameterValue = Convert.ToString(id)
            };
            PocketInfoEntities pocketDetail = new PocketInfoEntities();
            int DeletedRecords = ServiceMethods.GenerateDeleteRequest(id, serviceInputsForDocType);

            return RedirectToAction("PocketDetail");
        }

        public ActionResult CreatePocket()
        {
            PocketModel pocketModel = new PocketModel();
            pocketModel.pocketInfo = new PocketInfoEntities();
            
            pocketModel.pocketInfo.PocketVillageMappingList = new List<PocketVillageMappingEntities>();
            PocketVillageMappingEntities villageMappingEntities = new PocketVillageMappingEntities();
            pocketModel.pocketInfo.PocketVillageMappingList.Add(villageMappingEntities);

            pocketModel.pocketInfo.PocketCropMappingList = new List<PocketCropMappingEntities>();
            pocketModel.pocketInfo.PocketCropMappingList.Add(new PocketCropMappingEntities());

            pocketModel.pocketInfo.PocketFertilizerMappingList = new List<PocketFertilizerMappingEntities>();
            pocketModel.pocketInfo.PocketFertilizerMappingList.Add(new PocketFertilizerMappingEntities());

            pocketModel.ActionType = ActionTypeEnum.Insert;
            return View(pocketModel);
        }


        private List<StateInfoEntities> GetStateList()
        {
            List<StateInfoEntities> stateInfoEntities = null;
            ServiceInputObject serviceObject = new ServiceInputObject
             {
                 baseURL = ConfigSettings.WebApiBaseAddress,
                 controllerName = "State",
                 methodName = "GetAllStates",
             };
            stateInfoEntities = ServiceMethods.GenerateGatRequest<List<StateInfoEntities>>(serviceObject);

            return stateInfoEntities;
        }

        [HttpPost]
        public ActionResult GetDistrictByStateId(string stateId)
        {

            stateId = Convert.ToString(JsonConvert.DeserializeObject<int>(stateId));
            ServiceInputObject serviceObject = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "District",
                methodName = "GetDistrictOfState",
                parameterValue = stateId
            };
            List<DistrictInfoEntities> districtInfo = ServiceMethods.GenerateGatRequest<List<DistrictInfoEntities>>(serviceObject);
            List<SelectListItem> districtList = CommonOperations.BindDropdwon<DistrictInfoEntities>(districtInfo, "DistID", "DistrictName");

            return Json(districtList);
        }
        [HttpPost]
        public ActionResult GetSubDistrictByDistrictId(string districtId)
        {
            districtId = Convert.ToString(JsonConvert.DeserializeObject<int>(districtId));
            ServiceInputObject serviceObject = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "SubDistrict",
                methodName = "GetSubDistrictsOfDistrict",
                parameterValue = districtId
            };

            List<SubDistrictInfoEntities> subDistrictInfo = ServiceMethods.GenerateGatRequest<List<SubDistrictInfoEntities>>(serviceObject);
            List<SelectListItem> subDistrictList = CommonOperations.BindDropdwon<SubDistrictInfoEntities>(subDistrictInfo, "SubDistID", "SubDistrictName");
            return Json(subDistrictList);
        }
        [HttpPost]
        public ActionResult GetVillageBySubDistrictId(string subDistrictId)
        {
            subDistrictId = Convert.ToString(JsonConvert.DeserializeObject<int>(subDistrictId));
            ServiceInputObject serviceObject = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "Village",
                methodName = "GetVillageListofSubDistrict",
                parameterValue = subDistrictId
            };

            List<VillageInfoEntities> villageInfoEntities = ServiceMethods.GenerateGatRequest<List<VillageInfoEntities>>(serviceObject);
            List<SelectListItem> villageList = CommonOperations.BindDropdwon<VillageInfoEntities>(villageInfoEntities,"VillageID","VILLAGE");
            return Json(villageList);
        } 

        [HttpPost]
        public ActionResult InsertPocket(string pocketData)
        {
            PocketModel pocketModel = JsonConvert.DeserializeObject<PocketModel>(pocketData);
            pocketModel.pocketInfo.CreatedBy = SessionManager.UserId;
            pocketModel.pocketInfo.UpdatedBy = SessionManager.UserId;

            ServiceInputObject serviceInputsForInsertion = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "Pocket",
                methodName = "PostPocketDetail"
            };
            int returnValue = ServiceMethods.GeneratePostRequestWithIntDestinationEntity<PocketInfoEntities>(pocketModel.pocketInfo, serviceInputsForInsertion);


            return Json("Data Successfully Inserted");
        }
        [HttpPost]
        public ActionResult UpdatePocket(string pocketData)
        {
            PocketModel pocketModel = JsonConvert.DeserializeObject<PocketModel>(pocketData);
            pocketModel.pocketInfo.UpdatedBy = SessionManager.UserId;

            ServiceInputObject serviceInputsForUpdation = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "Pocket",
                methodName = "PutPocketDetail"
            };
            int returnValue = ServiceMethods.GeneratePutRequestIntDestinationEntity<PocketInfoEntities>(pocketModel.pocketInfo, serviceInputsForUpdation);


            return Json("Data Successfully Updated");
        }

        [HttpPost]
        public ActionResult GetPocketInitialValues()
        {
            ServiceInputObject serviceObject = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "Pocket",
                methodName = "GetPocketPageUIvalues"
            };

            PocketPageUIvalues pageUiValues = ServiceMethods.GenerateGatRequest<PocketPageUIvalues>(serviceObject);

            PocketDropdownValueForAddPage dropdownValue = new PocketDropdownValueForAddPage();
            dropdownValue.states = CommonOperations.BindDropdwon<StateInfoEntities>(pageUiValues.states, "StateID", "StateName");
            dropdownValue.crops=CommonOperations.BindDropdwon<CropInfoEntities>(pageUiValues.crops, "CropID", "CropName");
            dropdownValue.fertilizers = CommonOperations.BindDropdwon<FertilizerInfoEntities>(pageUiValues.fertilizers, "Id", "Fertilizer");
            dropdownValue.pocketStatusList = CommonOperations.BindDropdwon<PocketStatusEntities>(pageUiValues.pocketStatusList, "Id", "PocketStatus");
            return Json(dropdownValue);
            
        }
    }

    
}