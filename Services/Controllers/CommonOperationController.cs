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
using BusinessEntities.Enums;
using Services.Common;
using BusinessEntities.PageUIValues;
namespace Services.Controllers
{
    [RoutePrefix("api/CommonOperation")]
    public class CommonOperationController : ApiController
    {
        [Route("FAdetailPageUIvalues")]
        public FAdetailPageUIvalues GetFAdetailPageUIvalues()
        {

            FAdetailPageUIvalues pageUIvalues = new FAdetailPageUIvalues();

            IFAdesignationOperations faDesignationOperation = new FAdesignationOperations();
            pageUIvalues.DesignationList = MapEntities.MapIEnumerableCollection<FAdesignation, FAdesignationEntities>(faDesignationOperation.GetFAdesignationList()).ToList();

            IFAdocumentTypeOperations faDocumentTypeOperations = new FAdocumentTypeOperations();
            pageUIvalues.DocumentTypeList = MapEntities.MapIEnumerableCollection<FAdocumentType, FAdocumentTypeEntities>(faDocumentTypeOperations.GetFAdocumentTypeList()).ToList();

            //IDistrictInfoOperations districtInfoOperations = new DistrictInfoOperations();
            //pageUIvalues.DistrictList = MapEntities.MapIEnumerableCollection<DistrictInfo, DistrictInfoEntities>(districtInfoOperations.GetAllDistricts()).ToList();

            IFApaymentAgencyOperations paymentAgencyOperations = new FApaymentAgencyOperations();
            pageUIvalues.PaymentAgencyList = MapEntities.MapIEnumerableCollection<FApaymentAgency, FApaymentAgencyEntities>(paymentAgencyOperations.GetAllPaymentAgency()).ToList();

            IFAstatusOperations targetStatusOperations = new FAstatusOperations();
            pageUIvalues.FAstatusList = MapEntities.MapIEnumerableCollection<FAStatu, FAstatusEntities>(targetStatusOperations.GetFAStatusList()).ToList();

            IDealerDetailOperations dealerDetailOperations = new DealerDetailOperations();
            pageUIvalues.DealerList = MapEntities.MapIEnumerableCollection<DealerDetail, DealerDetailEntities>(dealerDetailOperations.GetAllDealerList()).ToList();

            ICropInfoOperations cropInfoOperations = new CropInfoOperations();
            pageUIvalues.CropList = MapEntities.MapIEnumerableCollection<CropInfo, CropInfoEntities>(cropInfoOperations.GetAllCrops()).ToList();

            //IPocketInfoOperations pocketInfoOperations = new PocketInfoOperations();
            //pageUIvalues.PocketList = MapEntities.MapIEnumerableCollection<PocketInfo, PocketInfoEntities>(pocketInfoOperations.GetPocketList()).ToList();

            IFaApprovedByOperations faApprovedBY = new FaApprovedByOperations();
            pageUIvalues.approvedByList = MapEntities.MapIEnumerableCollection<FAapprovedBy, FAapprovedByEntities>(faApprovedBY.GetApprovedByList()).ToList();

            IStateInfoOperations stateOperation = new StateInfoOperations();
            pageUIvalues.stateList = MapEntities.MapList<StateInfo, StateInfoEntities>(stateOperation.GetAllStates());


            return pageUIvalues;

        }
    }
}
