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
    [RoutePrefix("api/FAdetail")]
    public class FAdetailController : ApiController
    {
        [Route("PostFAdetailEntities")]
        public int PostFAdetailEntities(FAdetailEntities faDetailEntities)
        {
            try
            {
                IFAdetailOperations faDetailOperations = new FAdetailOperations();
                IFAaddressDetailOperations faAddressDetailOperation = new FAaddressDetailOperations();
                IFAeducationDetailOperations faEducationDetailOperation = new FAeducationDetailOperations();
                IFAexperianceDetailOperations faExperienceDetailOperation = new FAexperianceDetailOperations();
                IFAtargetOperations faTargetOperation = new FAtargetOperations();
                IFAtargetVillageMappingOperations targetVillageMappingOperation = new FAtargetVillageMappingOperations();
                IFAapprovalOperations faApprovalOperation = new FAapprovalOperations();

                IFAuploadedDocumentDetailOperations faUploadDocumentDetailOperations = new FAuploadedDocumentDetailOperations();

                FAdetail faDetail = new FAdetail();
                faDetail = MapEntities.Map<FAdetailEntities, FAdetail>(faDetailEntities);
                int faDetailId = faDetailOperations.InsertFAdetail(faDetail);

                FAaddressDetail faAddressDetail = new FAaddressDetail();
                faAddressDetail = MapEntities.Map<FAaddressDetailEntities, FAaddressDetail>(faDetailEntities.AddressDetailEntities);
                faAddressDetail.FAdetailId = faDetailId;
                int faAddressDetailId = faAddressDetailOperation.InsertFAAddressDetail(faAddressDetail);

                IEnumerable<FAeducationDetail> faEducationDetailList = new List<FAeducationDetail>();
                faEducationDetailList = MapEntities.MapIEnumerableCollection<FAeducationDetailEntities, FAeducationDetail>(faDetailEntities.EducationDetailEntityList);
                faEducationDetailList.ToList().ForEach(x => x.FAid = faDetailId);
                faEducationDetailList = faEducationDetailOperation.InsertFAeducationDetail(faEducationDetailList);

                IEnumerable<FAexperianceDetail> faExperienceDetailList = new List<FAexperianceDetail>();
                faExperienceDetailList = MapEntities.MapIEnumerableCollection<FAexperianceDetailEntities, FAexperianceDetail>(faDetailEntities.ExperienceDetailEntityList);
                faExperienceDetailList.ToList().ForEach(x => x.FAid = faDetailId);
                faExperienceDetailList = faExperienceDetailOperation.InsertFAexperienceDetail(faExperienceDetailList);

                IEnumerable<FAtargetDetail> faTargetDetailList = new List<FAtargetDetail>();
                faTargetDetailList = MapEntities.MapIEnumerableCollection<FAtargetDetailEntities, FAtargetDetail>(faDetailEntities.TargetDetailEntityList);
                faTargetDetailList.ToList().ForEach(x => x.FAid = faDetailId);
                for (int faTargetEntityCount = 0; faTargetEntityCount < faDetailEntities.TargetDetailEntityList.Count(); faTargetEntityCount++)
                {
                    faTargetDetailList.ElementAt(faTargetEntityCount).FAtargetVillageMappings = MapEntities.MapIEnumerableCollection<FAtargetVillageMappingEntities, FAtargetVillageMapping>(faDetailEntities.TargetDetailEntityList.ElementAt(faTargetEntityCount).TargetCropsEntityMappingList).ToList();
                }
                faTargetDetailList = faTargetOperation.InsertTargetsForFA(faTargetDetailList);

                FAapproval faApproval = new FAapproval();
                faApproval = MapEntities.Map<FAapprovalEntities, FAapproval>(faDetailEntities.ApprovalEntities);
                faApproval.FAid = faDetailId;
                faApproval = faApprovalOperation.InsertFAapproval(faApproval);

                IEnumerable<FAuploadedDocumentDetail> fauploadDetailList = new List<FAuploadedDocumentDetail>();
                fauploadDetailList = MapEntities.MapIEnumerableCollection<FAuploadedDocumentDetailEntities, FAuploadedDocumentDetail>(faDetailEntities.UploadedDocumentList);
                fauploadDetailList.ToList().ForEach(x => x.FAid = faDetailId);
                fauploadDetailList = faUploadDocumentDetailOperations.InsertUploadedDocumentDetailIst(fauploadDetailList);

                return faDetailId;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        [Route("GetAllFAdetailEntities")]
        
        public List<FAdetailEntities> GetFAdetailEntities()
        {
            try
            {
                IFAdetailOperations faDetailOperation = new FAdetailOperations();
                List<FAdetail> faDetailList = faDetailOperation.GetFAdetailList();
                List<FAdetailEntities> faDetailEntities = MapEntities.MapIEnumerableCollection<FAdetail, FAdetailEntities>(faDetailList).ToList();

                for (int faDetailCount = 0; faDetailCount < faDetailEntities.Count(); faDetailCount++)
                {
                    faDetailEntities.ElementAt(faDetailCount).AddressDetailEntities = faDetailList.ElementAt(faDetailCount).FAaddressDetails != null ? MapEntities.Map<FAaddressDetail, FAaddressDetailEntities>(faDetailList.ElementAt(faDetailCount).FAaddressDetails.ElementAt(0)) : new FAaddressDetailEntities();
                    faDetailEntities.ElementAt(faDetailCount).ApprovalEntities = faDetailList.ElementAt(faDetailCount).FAapprovals.ElementAt(0) != null ? MapEntities.Map<FAapproval, FAapprovalEntities>(faDetailList.ElementAt(faDetailCount).FAapprovals.ElementAt(0)) : new FAapprovalEntities();
                    faDetailEntities.ElementAt(faDetailCount).EducationDetailEntityList = MapEntities.MapList<FAeducationDetail, FAeducationDetailEntities>(faDetailList.ElementAt(faDetailCount).FAeducationDetails.ToList());
                    faDetailEntities.ElementAt(faDetailCount).ExperienceDetailEntityList = MapEntities.MapList<FAexperianceDetail, FAexperianceDetailEntities>(faDetailList.ElementAt(faDetailCount).FAexperianceDetails.ToList());
                    faDetailEntities.ElementAt(faDetailCount).TargetDetailEntityList = MapEntities.MapList<FAtargetDetail, FAtargetDetailEntities>(faDetailList.ElementAt(faDetailCount).FAtargetDetails.ToList());
                    faDetailEntities.ElementAt(faDetailCount).UploadedDocumentList = MapEntities.MapList<FAuploadedDocumentDetail, FAuploadedDocumentDetailEntities>(faDetailList.ElementAt(faDetailCount).FAuploadedDocumentDetails.ToList());
                    faDetailEntities.ElementAt(faDetailCount).StatusName = faDetailList.ElementAt(faDetailCount).FAStatu.FAstatus;
                    for (int targetMappingCount = 0; targetMappingCount < faDetailEntities.ElementAt(faDetailCount).TargetDetailEntityList.Count(); targetMappingCount++)
                    {
                        faDetailEntities.ElementAt(faDetailCount).TargetDetailEntityList.ElementAt(targetMappingCount).TargetCropsEntityMappingList = MapEntities.MapIEnumerableCollection<FAtargetVillageMapping, FAtargetVillageMappingEntities>(faDetailList.ElementAt(faDetailCount).FAtargetDetails.ElementAt(targetMappingCount).FAtargetVillageMappings).ToList();
                    }
                }

                return faDetailEntities;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        [HttpGet]
        public FAdetailEntities GetFAdetailEntityById(string id)
        {
            try
            {
                int id1 = Convert.ToInt32(id);
                IFAdetailOperations faDetailOperation = new FAdetailOperations();
                FAdetail faDetail = faDetailOperation.GetFAdetailById(id1);
                FAdetailEntities faDetailEntity;
                PocketController pocketController = new PocketController();
                DistrictController districtContorller = new DistrictController();
                if (faDetail != null)
                {
                    faDetailEntity = MapEntities.Map<FAdetail, FAdetailEntities>(faDetail);
                    faDetailEntity.AddressDetailEntities = faDetail.FAaddressDetails != null ? MapEntities.Map<FAaddressDetail, FAaddressDetailEntities>(faDetail.FAaddressDetails.ElementAt(0)) : new FAaddressDetailEntities();
                    faDetailEntity.AddressDetailEntities.DistrictList = districtContorller.GetDistrictOfState(faDetailEntity.AddressDetailEntities.StateId.Value);
                    faDetailEntity.AddressDetailEntities.PocketList = pocketController.GetActivePocketsByDistrictId(faDetailEntity.AddressDetailEntities.District.Value);
                    faDetailEntity.ApprovalEntities = faDetail.FAapprovals != null ? MapEntities.Map<FAapproval, FAapprovalEntities>(faDetail.FAapprovals.ElementAt(0)) : new FAapprovalEntities();
                    faDetailEntity.EducationDetailEntityList = faDetail.FAeducationDetails != null ? MapEntities.MapList<FAeducationDetail, FAeducationDetailEntities>(faDetail.FAeducationDetails.ToList()) : new List<FAeducationDetailEntities>();
                    faDetailEntity.ExperienceDetailEntityList = faDetail.FAexperianceDetails != null ? MapEntities.MapList<FAexperianceDetail, FAexperianceDetailEntities>(faDetail.FAexperianceDetails.ToList()) : new List<FAexperianceDetailEntities>();
                    faDetailEntity.TargetDetailEntityList = MapEntities.MapList<FAtargetDetail, FAtargetDetailEntities>(faDetail.FAtargetDetails.ToList());
                    faDetailEntity.UploadedDocumentList = MapEntities.MapList<FAuploadedDocumentDetail, FAuploadedDocumentDetailEntities>(faDetail.FAuploadedDocumentDetails.ToList());
                    faDetailEntity.pocketDetail = pocketController.GetPocketDetail(faDetailEntity.AddressDetailEntities.PocketId.Value);
                    faDetailEntity.StatusName = faDetail.FAStatu.FAstatus;
                   
                    for (int targetMappingCount = 0; targetMappingCount < faDetailEntity.TargetDetailEntityList.Count(); targetMappingCount++)
                    {
                        faDetailEntity.TargetDetailEntityList.ElementAt(targetMappingCount).TargetCropsEntityMappingList = MapEntities.MapIEnumerableCollection<FAtargetVillageMapping, FAtargetVillageMappingEntities>(faDetail.FAtargetDetails.ElementAt(targetMappingCount).FAtargetVillageMappings).ToList();
                    }
                }
                else
                {
                    faDetailEntity = new FAdetailEntities();
                }

                return faDetailEntity;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        [HttpDelete]
        public int DeleteFAdetailById( int id)
        {
            try
            {
                IFAdetailOperations faDetailOperation = new FAdetailOperations();
                int removedId = faDetailOperation.RemoveFAdetail(id);
                return removedId;
            }
            catch (Exception ex)
            {

                throw ex;
            }

           
        }
        [HttpPut]
        public int UpdateFAdetailById(FAdetailEntities faDetailEntities)
        {
            try
            {
                IFAdetailOperations faDetailOperation = new FAdetailOperations();

                List<FAaddressDetailEntities> addressDetailList = new List<FAaddressDetailEntities>();
                addressDetailList.Add(faDetailEntities.AddressDetailEntities);
                List<FAapprovalEntities> approvalDetailList = new List<FAapprovalEntities>();
                approvalDetailList.Add(faDetailEntities.ApprovalEntities);

                FAdetail faDetail;
                if (faDetailEntities != null)
                {
                    faDetail = MapEntities.Map<FAdetailEntities, FAdetail>(faDetailEntities);
                    faDetail.FAaddressDetails = faDetailEntities.AddressDetailEntities != null ? MapEntities.MapList<FAaddressDetailEntities, FAaddressDetail>(addressDetailList) : new List<FAaddressDetail>();
                    faDetail.FAapprovals = faDetailEntities.ApprovalEntities != null ? MapEntities.MapList<FAapprovalEntities, FAapproval>(approvalDetailList) : new List<FAapproval>();
                    faDetail.FAeducationDetails = faDetailEntities.EducationDetailEntityList != null ? MapEntities.MapList<FAeducationDetailEntities, FAeducationDetail>(faDetailEntities.EducationDetailEntityList) : new List<FAeducationDetail>();
                    faDetail.FAexperianceDetails = faDetailEntities.ExperienceDetailEntityList != null ? MapEntities.MapList<FAexperianceDetailEntities, FAexperianceDetail>(faDetailEntities.ExperienceDetailEntityList.ToList()) : new List<FAexperianceDetail>();
                    faDetail.FAtargetDetails = MapEntities.MapList<FAtargetDetailEntities, FAtargetDetail>(faDetailEntities.TargetDetailEntityList.ToList());
                    faDetail.FAuploadedDocumentDetails = faDetailEntities.UploadedDocumentList != null ? MapEntities.MapList<FAuploadedDocumentDetailEntities, FAuploadedDocumentDetail>(faDetailEntities.UploadedDocumentList.ToList()) : new List<FAuploadedDocumentDetail>();
                    faDetail.Status = faDetailEntities.Status;
                    for (int targetMappingCount = 0; targetMappingCount < faDetail.FAtargetDetails.Count(); targetMappingCount++)
                    {
                        faDetail.FAtargetDetails.ElementAt(targetMappingCount).FAtargetVillageMappings = MapEntities.MapIEnumerableCollection<FAtargetVillageMappingEntities, FAtargetVillageMapping>(faDetailEntities.TargetDetailEntityList.ElementAt(targetMappingCount).TargetCropsEntityMappingList).ToList();
                    }
                }
                else
                {
                    faDetail = new FAdetail();
                }

                int returnValue = faDetailOperation.UpdateFAdetail(faDetail);
                return returnValue;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
