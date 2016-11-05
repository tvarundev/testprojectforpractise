using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Models;
using BusinessEntities.EntityClasses;
using BusinessEntities.Enums;
using Application.Common;
using Newtonsoft.Json;
using BusinessEntities.PageUIValues;
using Application.PageDropdownClasses;
namespace Application.Controllers
{
    public class FarmerDetailController : BaseController
    {
        // GET: FarmerDetail
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult FarmerDetail()
        {
            ServiceInputObject serviceInputObject = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "FarmerDetail",
                parameterValue = string.Empty
            };
            List<FarmerDetailEntities> farmerDetailList = ServiceMethods.GenerateGatRequest<List<FarmerDetailEntities>>(serviceInputObject);

            return View(farmerDetailList);
        }

        public ActionResult AddFarmerDetail()
        {
            FarmerDetailModel farmerDetailModel = new FarmerDetailModel();
            farmerDetailModel.farmerDetail = new FarmerDetailEntities();
            FarmerDetailPageUIvalues pageUIValues = GetPageUIvalues();
            farmerDetailModel.crops = CommonOperations.BindDropdwon<CropInfoEntities>(pageUIValues.CropList, "CropID", "CropName");
            farmerDetailModel.farmerTypes = CommonOperations.BindDropdwon<FarmerTypeEntities>(pageUIValues.FarmerTypeList, "id", "farmerType");
            farmerDetailModel.countryCodes = CommonOperations.GetCountryCodes();
            farmerDetailModel.DealerList = CommonOperations.BindDropdwon<DealerDetailEntities>(pageUIValues.DealerList, "id", "dealerName");
            farmerDetailModel.pocketList = CommonOperations.BindDropdwon<PocketInfoEntities>(pageUIValues.PocketList, "PocketID", "PocketName");
            farmerDetailModel.irrigationSourceList = CommonOperations.BindDropdwon<IrrigationSourceEntities>(pageUIValues.irrigationSourceList, "Id", "SourceName").ToList();
            farmerDetailModel.farmerDetail.farmerLandMappingList.Add(new FarmerLandMappingEntities());
            farmerDetailModel.farmerDetail.farmerConsumptionMappingList.Add(new FarmerConsumptionMappingEntities());
            farmerDetailModel.farmerDetail.farmerCropMappingList.Add(new FarmerCropMappingEntities());
            farmerDetailModel.farmerDetail.farmerPestiesMappingList.Add(new FarmerPesticesMappingEntities());
            farmerDetailModel.farmerDetail.inputSoruceList.Add(new FarmerInputSourceMappingEntities());
            farmerDetailModel.Action = ActionTypeEnum.Insert;

            return View("AddFarmerDetail",farmerDetailModel);
        }
        [HttpPost]
        public int AddNewFarmerDetail(string farmerDetailString)
        {
            FarmerDetailEntities FarmerDetail = JsonConvert.DeserializeObject<FarmerDetailEntities>(farmerDetailString);
            ServiceInputObject serviceInputObject = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "FarmerDetail",
                parameterValue = string.Empty
            };
            FarmerDetail = ServiceMethods.GeneratePostRequest<FarmerDetailEntities>(FarmerDetail, serviceInputObject);

            return FarmerDetail.Id;
        }

        [HttpPost]
        public int UpdateExistingFarmerDetail(string farmerDetailString)
        {
            FarmerDetailEntities FarmerDetail = JsonConvert.DeserializeObject<FarmerDetailEntities>(farmerDetailString);
            ServiceInputObject serviceInputObject = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "FarmerDetail",
                parameterValue = string.Empty
            };
            int id = ServiceMethods.GeneratePutRequestIntDestinationEntity<FarmerDetailEntities>(FarmerDetail, serviceInputObject);

            return id;
        }

        public ActionResult SelectedFarmerDetail(int id)
        {
            ServiceInputObject serviceInputObject = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "FarmerDetail",
                parameterValue =Convert.ToString( id)
            };
            FarmerDetailEntities farmerDetail = ServiceMethods.GenerateGatRequest<FarmerDetailEntities>(serviceInputObject);

            FarmerDetailModel farmerDetailModel = new FarmerDetailModel();
            FarmerDetailPageUIvalues pageUIValues = GetPageUIvalues();
            farmerDetailModel.crops = CommonOperations.BindDropdwon<CropInfoEntities>(pageUIValues.CropList, "CropID", "CropName");
            farmerDetailModel.farmerTypes = CommonOperations.BindDropdwon<FarmerTypeEntities>(pageUIValues.FarmerTypeList, "id", "farmerType");
            farmerDetailModel.countryCodes = CommonOperations.GetCountryCodes();
            farmerDetailModel.DealerList = CommonOperations.BindDropdwon<DealerDetailEntities>(pageUIValues.DealerList, "id", "dealerName");
            farmerDetailModel.pocketList = CommonOperations.BindDropdwon<PocketInfoEntities>(pageUIValues.PocketList, "PocketID", "PocketName");
            farmerDetailModel.irrigationSourceList = CommonOperations.BindDropdwon<IrrigationSourceEntities>(pageUIValues.irrigationSourceList, "Id", "SourceName").ToList();
            farmerDetailModel.isInDetailMode = true;
            farmerDetailModel.farmerDetail = farmerDetail;
            farmerDetailModel.Action = ActionTypeEnum.Select;

            return View("AddFarmerDetail", farmerDetailModel);
        }
        public ActionResult DeleteFarmerDetail(int id)
        {
            ServiceInputObject serviceInputObject = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "FarmerDetail",
                parameterValue = Convert.ToString(id)
            };
            int deletedRecordId = ServiceMethods.GenerateDeleteRequest(id,serviceInputObject);

            return RedirectToAction("FarmerDetail"); ;
        }

        public ActionResult UpdateFarmerDetail(int id)
        {
            ServiceInputObject serviceInputObject = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "FarmerDetail",
                parameterValue = Convert.ToString(id)
            };
            FarmerDetailEntities farmerDetail = ServiceMethods.GenerateGatRequest<FarmerDetailEntities>(serviceInputObject);

            FarmerDetailModel farmerDetailModel = new FarmerDetailModel();
            FarmerDetailPageUIvalues pageUIValues = GetPageUIvalues();
            farmerDetailModel.crops = CommonOperations.BindDropdwon<CropInfoEntities>(pageUIValues.CropList, "CropID", "CropName");
            farmerDetailModel.farmerTypes = CommonOperations.BindDropdwon<FarmerTypeEntities>(pageUIValues.FarmerTypeList, "id", "farmerType");
            farmerDetailModel.countryCodes = CommonOperations.GetCountryCodes();
            farmerDetailModel.DealerList = CommonOperations.BindDropdwon<DealerDetailEntities>(pageUIValues.DealerList, "id", "dealerName");
            farmerDetailModel.pocketList = CommonOperations.BindDropdwon<PocketInfoEntities>(pageUIValues.PocketList, "PocketID", "PocketName");
            farmerDetailModel.irrigationSourceList = CommonOperations.BindDropdwon<IrrigationSourceEntities>(pageUIValues.irrigationSourceList, "Id", "SourceName").ToList();
            farmerDetailModel.isInDetailMode = false;
            farmerDetailModel.farmerDetail = farmerDetail;
            farmerDetailModel.Action = ActionTypeEnum.Update ;

            farmerDetailModel.farmerDetail.farmerConsumptionMappingList.ForEach(x => { x.ConsumptionList = pageUIValues.farmerConsumptionlist; });

            return View("AddFarmerDetail", farmerDetailModel);
        }
        private FarmerDetailPageUIvalues GetPageUIvalues()
        {
            ServiceInputObject serviceInputObject = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "FarmerDetail",
                methodName="GetFarmerDetailPageUIvalues",
                parameterValue=string.Empty
            };
            FarmerDetailPageUIvalues pageUIvalues = ServiceMethods.GenerateGatRequest<FarmerDetailPageUIvalues>(serviceInputObject);
            return pageUIvalues;
        }
        public ActionResult GetPageUIvaluesForPocket(string pocketId)
        {
            pocketId = Convert.ToString(JsonConvert.DeserializeObject<int>(pocketId));
            ServiceInputObject serviceInputObject = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "FarmerDetail",
                methodName = "GetPocketMappingData",
                parameterValue = pocketId
            };
            FarmerDetailPageUIvalues pageUIvalues = ServiceMethods.GenerateGatRequest<FarmerDetailPageUIvalues>(serviceInputObject);

            
            PocketDropdownValueForAddPage dropdownValue = new PocketDropdownValueForAddPage();
            
            dropdownValue.crops = CommonOperations.BindDropdwon<CropInfoEntities>(pageUIvalues.CropList, "CropID", "CropName");
            dropdownValue.villages = CommonOperations.BindDropdwon<VillageInfoEntities>(pageUIvalues.villageList, "VillageID", "VILLAGE");

            return Json(dropdownValue);
            
        }
    }
}