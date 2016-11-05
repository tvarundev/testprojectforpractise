using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities.Enums;
using BusinessEntities.EntityClasses;
using Application.Common;
using Application.Models;
using Newtonsoft.Json;
using BusinessEntities.PageUIValues;
namespace Application.Controllers
{
    
    public class FAdetailController : BaseController
    {
        public ActionResult AddFA()
        {
            FAdetailModel faDetailModel = new FAdetailModel();
            faDetailModel.faDetailPageUIvalues = new FAdetailPageUIvalues();

            faDetailModel.faDetailPageUIvalues = GetFAdetailPageUiValues();
            faDetailModel.faDetailEntities = new FAdetailEntities();
            faDetailModel.faDetailEntities.AddressDetailEntities = new FAaddressDetailEntities();
            faDetailModel.faDetailEntities.ApprovalEntities = new FAapprovalEntities();

            faDetailModel.faDetailEntities.EducationDetailEntityList = new List<FAeducationDetailEntities>();
            FAeducationDetailEntities educationDetail = new FAeducationDetailEntities();
            faDetailModel.faDetailEntities.EducationDetailEntityList.Add(educationDetail);

            faDetailModel.faDetailEntities.ExperienceDetailEntityList = new List<FAexperianceDetailEntities>();
            FAexperianceDetailEntities experienceDetail = new FAexperianceDetailEntities();
            faDetailModel.faDetailEntities.ExperienceDetailEntityList.Add(experienceDetail);

            faDetailModel.faDetailEntities.TargetDetailEntityList = new List<FAtargetDetailEntities>();
            FAtargetDetailEntities targetDetail = new FAtargetDetailEntities();
            faDetailModel.faDetailEntities.TargetDetailEntityList.Add(targetDetail);

            faDetailModel.faDetailEntities.TargetDetailEntityList.ToList().ForEach(x => { x.TargetCropsEntityMappingList = new List<FAtargetVillageMappingEntities>(); });
            FAtargetVillageMappingEntities targetVillage = new FAtargetVillageMappingEntities();
            faDetailModel.faDetailEntities.TargetDetailEntityList.ForEach(x => { x.TargetCropsEntityMappingList.Add(targetVillage); });

            faDetailModel.faDetailEntities.UploadedDocumentList = new List<FAuploadedDocumentDetailEntities>();
            FAuploadedDocumentDetailEntities uploadDocument = new FAuploadedDocumentDetailEntities();
            faDetailModel.faDetailEntities.UploadedDocumentList.Add(uploadDocument);

            faDetailModel.faDetailPageUIvalues.DistrictList = new List<DistrictInfoEntities>();
            faDetailModel.faDetailPageUIvalues.subDistrictList = new List<SubDistrictInfoEntities>();
            faDetailModel.faDetailPageUIvalues.VillageList = new List<VillageInfoEntities>();
            

            faDetailModel.ActionType = ActionTypeEnum.Insert;
            faDetailModel.faDetailEntities.EnrollDate = DateTime.Now;
            faDetailModel.faDetailEntities.IsExperienced = true;
            faDetailModel.faDetailEntities.Id = 0;

            return View(faDetailModel);
        }
        public ActionResult SelectedFA(int id)
        {
            FAdetailModel faDetailModel = new FAdetailModel();
            faDetailModel.faDetailPageUIvalues = new FAdetailPageUIvalues();
            ServiceInputObject serviceInputsForDocType = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "FAdetail",
                methodName = "GetFAdetailEntityById",
                parameterValue=Convert.ToString(id)
            };
            FAdetailEntities faDetailEntity = new FAdetailEntities();
            faDetailEntity = ServiceMethods.GenerateGatRequest<FAdetailEntities>(serviceInputsForDocType);
            faDetailModel.faDetailPageUIvalues = GetFAdetailPageUiValues();
            faDetailModel.faDetailPageUIvalues = SetPocketDetailForModel(faDetailEntity.pocketDetail, faDetailEntity.AddressDetailEntities, faDetailModel.faDetailPageUIvalues);
            faDetailModel.faDetailEntities = faDetailEntity;
            faDetailModel.isInDetailMode = true;
            faDetailModel.ActionType = ActionTypeEnum.Select;
            return View("AddFA",faDetailModel);

        }
        public ActionResult FADetail()
        {
            ServiceInputObject serviceInputsForDocType = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "FAdetail",
                methodName = "GetAllFAdetailEntities"
            };
            List<FAdetailEntities> faDetailList = new List<FAdetailEntities>();
            faDetailList = ServiceMethods.GenerateGatRequest<List<FAdetailEntities>>(serviceInputsForDocType);

            //TODO: Change experience Dropdown to default yes 
            return View(faDetailList);
        }
        public ActionResult DeleteFAdetail(int id)
        {
            ServiceInputObject serviceInputsForDocType = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "FAdetail",
                methodName = "DeleteFAdetailById",
                parameterValue=Convert.ToString(id)
            };
            int DeletedRecordId = ServiceMethods.GenerateDeleteRequest(id, serviceInputsForDocType);
            return RedirectToAction("FADetail");
        }

        public ActionResult UpdateFAdetail(int id)
        {
            FAdetailModel faDetailModel = new FAdetailModel();
            faDetailModel.faDetailPageUIvalues = new FAdetailPageUIvalues();
            ServiceInputObject serviceInputsForDocType = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "FAdetail",
                methodName = "GetFAdetailEntityById",
                parameterValue = Convert.ToString(id)
            };
            FAdetailEntities faDetailEntity = new FAdetailEntities();
            faDetailEntity = ServiceMethods.GenerateGatRequest<FAdetailEntities>(serviceInputsForDocType);
            faDetailModel.faDetailPageUIvalues = GetFAdetailPageUiValues();
            faDetailModel.faDetailPageUIvalues = SetPocketDetailForModel(faDetailEntity.pocketDetail, faDetailEntity.AddressDetailEntities, faDetailModel.faDetailPageUIvalues);
            faDetailModel.faDetailEntities = faDetailEntity;
            faDetailModel.ActionType = ActionTypeEnum.Update;
            return View("AddFA", faDetailModel);
        }
        

        [HttpPost]
        public void GetNewFAdetail(string faDetailJsonString)
        {
            FAdetailModel model = JsonConvert.DeserializeObject<FAdetailModel>(faDetailJsonString);
            ServiceInputObject serviceInputsForDocType = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "FAdetail",
                methodName = "PostFAdetailEntities"
            };
            model.faDetailEntities.CreatedBy = SessionManager.UserId;
            model.faDetailEntities.UpdatedBy = SessionManager.UserId;
            model.faDetailEntities.CreatedDate = DateTime.Now;
            model.faDetailEntities.LastUpdated = DateTime.Now;
            int returnValue = ServiceMethods.GeneratePostRequestWithIntDestinationEntity<FAdetailEntities>(model.faDetailEntities, serviceInputsForDocType);
        }
        [HttpPost]
        public void UpdateFAdetail(string faDetailJsonString)
        {
            FAdetailModel model = JsonConvert.DeserializeObject<FAdetailModel>(faDetailJsonString);
            ServiceInputObject serviceInputsForDocType = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "FAdetail",
                methodName = "UpdateFAdetailById"
            };
            model.faDetailEntities.UpdatedBy = SessionManager.UserId;
            model.faDetailEntities.LastUpdated = DateTime.Now;
            int returnValue = ServiceMethods.GeneratePutRequestIntDestinationEntity<FAdetailEntities>(model.faDetailEntities, serviceInputsForDocType);
        }


        [HttpPost]
        public ActionResult GetDistrictsOfPocket(string pocketId)
        {
            pocketId = Convert.ToString(JsonConvert.DeserializeObject<int>(pocketId));
            ServiceInputObject serviceInputsForDocType = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "Pocket",
                methodName = "GetPocketDetail",
                parameterValue = pocketId
            };
            PocketInfoEntities pocketDetail = new PocketInfoEntities();
            pocketDetail = ServiceMethods.GenerateGatRequest<PocketInfoEntities>(serviceInputsForDocType);
            List<SelectListItem> Districts = CommonOperations.BindDropdwon<DistrictInfoEntities>(pocketDetail.districts, "DistID", "DistrictName");
            return Json(Districts);
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
        public ActionResult GetPocketByDistrictId(string districtId)
        {

            districtId = Convert.ToString(JsonConvert.DeserializeObject<int>(districtId));
            ServiceInputObject serviceObject = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "Pocket",
                methodName = "GetActivePocketsByDistrictId",
                parameterValue = districtId
            };
            List<PocketInfoEntities> pocketIfo = ServiceMethods.GenerateGatRequest<List<PocketInfoEntities>>(serviceObject);
            List<SelectListItem> pocketList = CommonOperations.BindDropdwon<PocketInfoEntities>(pocketIfo, "PocketID", "PocketName");

            return Json(pocketList);
        }
        [HttpPost]
        public ActionResult GetSubDistrictsOfPocket(string pocketId)
        {
            pocketId = Convert.ToString(JsonConvert.DeserializeObject<int>(pocketId));
            ServiceInputObject serviceInputsForDocType = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "Pocket",
                methodName = "GetPocketDetail",
                parameterValue = pocketId
            };
            PocketInfoEntities pocketDetail = new PocketInfoEntities();
            pocketDetail = ServiceMethods.GenerateGatRequest<PocketInfoEntities>(serviceInputsForDocType);

            List<SubDistrictInfoEntities> subDistricts = new List<SubDistrictInfoEntities>();
            foreach (var villageMapping in pocketDetail.PocketVillageMappingList)
            {
                subDistricts.AddRange(villageMapping.subDistricts);
            }
            subDistricts = subDistricts.Distinct(new DistinctItemComparer()).ToList();
            List<SelectListItem> SubDistricts = CommonOperations.BindDropdwon<SubDistrictInfoEntities>(subDistricts, "SubDistID", "SubDistrictName");
            return Json(SubDistricts);
        }
        [HttpPost]
        public ActionResult GetVillagesOfSubDistrictPocket(string pocketId,string SubDistrictId)
        {
            pocketId = Convert.ToString(JsonConvert.DeserializeObject<int>(pocketId));
            ServiceInputObject serviceInputsForDocType = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "Pocket",
                methodName = "GetPocketDetail",
                parameterValue = pocketId
            };
            PocketInfoEntities pocketDetail = new PocketInfoEntities();
            pocketDetail = ServiceMethods.GenerateGatRequest<PocketInfoEntities>(serviceInputsForDocType);

            List<PocketVillageMappingEntities> pocketVillages = new List<PocketVillageMappingEntities>();
            pocketVillages = pocketDetail.PocketVillageMappingList.Select(x => x).Where(x => x.SubDistrictId == Convert.ToInt32(SubDistrictId)).ToList();

            List<VillageInfoEntities> villageList = new List<VillageInfoEntities>();
            foreach(var villages in pocketVillages)
            {
                villageList.AddRange(villages.villages);
            }

            List<SelectListItem> FinalVillageList = CommonOperations.BindDropdwon<VillageInfoEntities>(villageList, "VillageID", "VILLAGE");
            return Json(FinalVillageList);
        }
        private FAdetailPageUIvalues GetFAdetailPageUiValues()
        {
            ServiceInputObject serviceInputsForDocType = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "CommonOperation",
                methodName = "FAdetailPageUIvalues"
            };
            FAdetailPageUIvalues fAdetailPageUIvalues = new FAdetailPageUIvalues();
            fAdetailPageUIvalues = ServiceMethods.GenerateGatRequest<FAdetailPageUIvalues>(serviceInputsForDocType);
            return fAdetailPageUIvalues;
        }
        private FAdetailPageUIvalues SetPocketDetailForModel(PocketInfoEntities pocketInfo, FAaddressDetailEntities faAddressDetailEntities,FAdetailPageUIvalues pageValues)
        {
            List<SubDistrictInfoEntities> subDistricts = new List<SubDistrictInfoEntities>();
            List<VillageInfoEntities> villages = new List<VillageInfoEntities>();
            foreach(var villageMapping in pocketInfo.PocketVillageMappingList)
            {
                subDistricts.AddRange(villageMapping.subDistricts);
            }
            subDistricts = subDistricts.Distinct(new DistinctItemComparer()).ToList();

            List<PocketVillageMappingEntities> pocketVillageList = pocketInfo.PocketVillageMappingList.Select(x => x).Where(x => x.SubDistrictId == faAddressDetailEntities.SubDistrictId).ToList();
            foreach(var villageItem in pocketVillageList)
            {
                villages.AddRange(villageItem.villages);
            }

            pageValues.subDistrictList = subDistricts;
            pageValues.VillageList = villages;
            pageValues.DistrictList = faAddressDetailEntities.DistrictList;
            pageValues.PocketList = faAddressDetailEntities.PocketList;
            return pageValues;
        }
    }
    class DistinctItemComparer : IEqualityComparer<SubDistrictInfoEntities>
    {

        public bool Equals(SubDistrictInfoEntities x, SubDistrictInfoEntities y)
        {
            return x.SubDistID == y.SubDistID;
        }

        public int GetHashCode(SubDistrictInfoEntities obj)
        {
            return obj.SubDistID.GetHashCode();
        }
    }
}