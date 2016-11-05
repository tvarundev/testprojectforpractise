using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities.EntityClasses;
using BusinessEntities.Enums;
using DataLayer.DBContext;
using DataLayer.Interfaces;
using DataLayer.Impelmentation;
using Services.Common;
using BusinessEntities.PageUIValues;
namespace Services.Controllers
{
    [RoutePrefix("api/FarmerDetail")]
    public class FarmerDetailController : ApiController
    {
        IfarmerDetailOperations farmerDetailOperations = new FarmerDetailOperations();
         //GET: api/FarmerDetail
        public IEnumerable<FarmerDetailEntities> Get()
        {
            try
            {

                IEnumerable<FarmerDetail> farmerDetailList = farmerDetailOperations.GetFarmerDetailList();
                List<FarmerDetailEntities> farmerDetailEntityList = MapEntities.MapIEnumerableCollection<FarmerDetail, FarmerDetailEntities>(farmerDetailList).ToList();

                return farmerDetailEntityList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        // GET: api/FarmerDetail/5
        public FarmerDetailEntities Get(int id)
        {
            try
            {
                FarmerDetail farmerDetail = farmerDetailOperations.GetFarmerDetailById(id);
                FarmerDetailEntities farmerDetailEntity = MapEntities.Map<FarmerDetail, FarmerDetailEntities>(farmerDetail);

                return farmerDetailEntity;
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // POST: api/FarmerDetail
        public FarmerDetailEntities Post(FarmerDetailEntities farmerDetail)
        {
            try
            {
                FarmerDetail farmerDetailToInsert = MapEntities.Map<FarmerDetailEntities, FarmerDetail>(farmerDetail);
                farmerDetailToInsert= farmerDetailOperations.InsertFarmerDetail(farmerDetailToInsert);
                FarmerDetailEntities insertedFarmerDetail = MapEntities.Map<FarmerDetail, FarmerDetailEntities>(farmerDetailToInsert);
                return insertedFarmerDetail;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
       
        // PUT: api/FarmerDetail/5
        public int Put(FarmerDetailEntities farmerDetailUpdated)
        {
            try
            {
                FarmerDetail farmerDetailToUpdate = MapEntities.Map<FarmerDetailEntities, FarmerDetail>(farmerDetailUpdated);
                farmerDetailToUpdate= farmerDetailOperations.UpdateFarmerDetail(farmerDetailToUpdate);
                return farmerDetailToUpdate.Id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // DELETE: api/FarmerDetail/5
        public int Delete(int id)
        {
            try
            {
                return farmerDetailOperations.DeleteFarmerDetail(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        [Route("GetFarmerDetailPageUIvalues")]
        public FarmerDetailPageUIvalues GetFarmerDetailPageUIvalues()
        {
            FarmerDetailPageUIvalues pageUIvalues = new FarmerDetailPageUIvalues();

            IDealerDetailOperations dealerDetailOperations = new DealerDetailOperations();
            pageUIvalues.DealerList = MapEntities.MapIEnumerableCollection<DealerDetail, DealerDetailEntities>(dealerDetailOperations.GetAllDealerList()).ToList();

            IfarmerTypeOperations farmerTypeOperations = new FarmerTypeOperations();
            pageUIvalues.FarmerTypeList =MapEntities.MapList<FarmerTypeDetail,FarmerTypeEntities>(farmerTypeOperations.GetAllFarmerType().ToList());

            IirrigationSourceOperations irrigationSourceOperation = new IrrigationSourceOperations();
            pageUIvalues.irrigationSourceList = MapEntities.MapList<IrrigationSource, IrrigationSourceEntities>(irrigationSourceOperation.GetAllIrrigationSources());

            ICropInfoOperations cropInfoOperations = new CropInfoOperations();
            pageUIvalues.CropList = MapEntities.MapList<CropInfo, CropInfoEntities>(cropInfoOperations.GetAllCrops().ToList());

            IPocketInfoOperations pocketInfoOperations = new PocketInfoOperations();
            pageUIvalues.PocketList = MapEntities.MapIEnumerableCollection<PocketInfo, PocketInfoEntities>(pocketInfoOperations.GetPocketList(Convert.ToInt32(PocketStatusTypeEnum.Current))).ToList();

            IFarmerConsumptionOperation farmerConsumptionOperation = new FarmerConsumptionOperation();
            pageUIvalues.farmerConsumptionlist = MapEntities.MapIEnumerableCollection<FarmerConsumption, FarmerConsumptionEntities>(farmerConsumptionOperation.GetFarmerConsumptionList()).ToList();

            return pageUIvalues;


        }
        [HttpGet]
        
        public FarmerDetailPageUIvalues GetPocketMappingData(int id)
        {
            FarmerDetailPageUIvalues pageUIvalues = new FarmerDetailPageUIvalues();

            ICropInfoOperations cropInfoOperations = new CropInfoOperations();
            pageUIvalues.CropList = MapEntities.MapList<CropInfo, CropInfoEntities>(cropInfoOperations.GetCropListOfPocket(id).ToList());

            IVillageInfoOperations villageOperation = new VillageInfoOperations();
            pageUIvalues.villageList = MapEntities.MapList<VillageInfo, VillageInfoEntities>(villageOperation.GetVillageListOfPocket(id)).ToList();
            
            return pageUIvalues;


        }
    }
}
