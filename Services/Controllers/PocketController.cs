using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities.EntityClasses;
using BusinessEntities.Enums;
using DataLayer.Interfaces;
using DataLayer.Impelmentation;
using DataLayer.DBContext;
using Services.Common;
using BusinessEntities.PageUIValues;
namespace Services.Controllers
{
    [RoutePrefix("api/Pocket")]
    public class PocketController : ApiController
    {
        public int PostPocketDetail(PocketInfoEntities pocketInfoEntities)
        {
            IPocketInfoOperations pocketOperations = new PocketInfoOperations();
            IPocketVillageMappingOperations pocketVillageMappingOperations = new PocketVillageMappingOperations();
            IPocketCropsMappingOperations pocketCropMappingOperations = new PocketCropsMappingOperations();
            IPocketFertilizerMappingOperations pocketFertilizerMappingOperations = new PocketFertilizerMappingOperations();

            PocketInfo pocketInfo = MapEntities.Map<PocketInfoEntities, PocketInfo>(pocketInfoEntities);
            List<PocketVillageMapping> pocketVillageEntities = MapEntities.MapList<PocketVillageMappingEntities, PocketVillageMapping>(pocketInfoEntities.PocketVillageMappingList);
            List<PocketCropMapping> pocketCropsEntities = MapEntities.MapList<PocketCropMappingEntities, PocketCropMapping>(pocketInfoEntities.PocketCropMappingList);
            List<PocketFertilizerMapping> pocketFertilizersEntities = MapEntities.MapList<PocketFertilizerMappingEntities, PocketFertilizerMapping>(pocketInfoEntities.PocketFertilizerMappingList);

            int pocketId = pocketOperations.InsertPocket(pocketInfo);
            pocketVillageEntities.ForEach(x => { x.PocketId = pocketId; });
            pocketCropsEntities.ForEach(x => { x.PocketId = pocketId; });
            pocketFertilizersEntities.ForEach(x => { x.PocketId = pocketId; });

            pocketVillageMappingOperations.InsertPocketVillageMappingOfPocket(pocketVillageEntities);
            pocketCropMappingOperations.InsertCropsOfPocket(pocketCropsEntities);
            pocketFertilizerMappingOperations.InsertFertilizersOfPocket(pocketFertilizersEntities);


            return pocketId;
        }

        public int PutPocketDetail(PocketInfoEntities pocketInfoEntities)
        {
            IPocketInfoOperations pocketOperations = new PocketInfoOperations();
            IPocketVillageMappingOperations pocketVillageMappingOperations = new PocketVillageMappingOperations();
            IPocketCropsMappingOperations pocketCropMappingOperations = new PocketCropsMappingOperations();
            IPocketFertilizerMappingOperations pocketFertilizerMappingOperations = new PocketFertilizerMappingOperations();

            PocketInfo pocketInfo = MapEntities.Map<PocketInfoEntities, PocketInfo>(pocketInfoEntities);
            List<PocketVillageMapping> pocketVillageEntities = MapEntities.MapList<PocketVillageMappingEntities, PocketVillageMapping>(pocketInfoEntities.PocketVillageMappingList);
            List<PocketCropMapping> pocketCropsEntities = MapEntities.MapList<PocketCropMappingEntities, PocketCropMapping>(pocketInfoEntities.PocketCropMappingList);
            List<PocketFertilizerMapping> pocketFertilizersEntities = MapEntities.MapList<PocketFertilizerMappingEntities, PocketFertilizerMapping>(pocketInfoEntities.PocketFertilizerMappingList);

            
            int UpdatedRecord = pocketOperations.UpdatePocket(pocketInfo);
            pocketVillageEntities.ForEach(x =>
            {
                x.PocketId = pocketInfo.PocketID;
            });
            pocketCropsEntities.ForEach(x =>
            {
                x.PocketId = pocketInfo.PocketID;
            });
            pocketFertilizersEntities.ForEach(x =>
            {
                x.PocketId = pocketInfo.PocketID;
            });

            pocketVillageMappingOperations.UpdatePocketVillageMappingOfPocket(pocketVillageEntities);
            pocketCropMappingOperations.UpdateCropsOfPocket(pocketCropsEntities);
            pocketFertilizerMappingOperations.UpdateFertilizersOfPocket(pocketFertilizersEntities);

            return UpdatedRecord;
        }
        public int DeletePocketDetail(int id)
        {
            IPocketInfoOperations pocketOperations = new PocketInfoOperations();
            
            int DeletedRecord = pocketOperations.UpdadteStatusOfPocket(id,Convert.ToInt16(PocketStatusTypeEnum.Discontinue));

            return DeletedRecord;
        }
        [HttpGet]
        public PocketInfoEntities GetPocketDetail(int id)
        {
            IPocketInfoOperations pocketOperations = new PocketInfoOperations();
            PocketInfo pocketInfo = pocketOperations.GetPockeById(id);
            return MapToBusinessEntity(pocketInfo);
        }
        [HttpGet]
        public PocketInfoEntities GetPocketDetailForUpdate(int id)
        {
            IPocketInfoOperations pocketOperations = new PocketInfoOperations();
            PocketInfo pocketInfo = pocketOperations.GetPockeById(id);
            return MapToBusinessEntityForUpdate(pocketInfo);
        }

        [HttpGet]
        public List<PocketInfoEntities> GetActivePocketsByDistrictId(int id)
        {
            //int districtId = 1;
            IPocketInfoOperations pocketOperations = new PocketInfoOperations();
            List<PocketInfo> pocketInfoList = pocketOperations.GetAllActivePocketListByDistrictId(id, Convert.ToInt32(PocketStatusTypeEnum.Current));

            List<PocketInfoEntities> pocketInfoEntityList = new List<PocketInfoEntities>();
            pocketInfoList.ForEach(x =>
            {
                pocketInfoEntityList.Add(MapToBusinessEntity(x));
            });
            return pocketInfoEntityList;
        }

        [HttpGet]
        [Route("GetPocketDetailList")]
        public List<PocketInfoEntities> GetPocketDetailList()
        {
            IPocketInfoOperations pocketOperations = new PocketInfoOperations();
            List<PocketInfo> pocketInfoList = pocketOperations.GetPocketList();

            List<PocketInfoEntities> pocketInfoEntityList = new List<PocketInfoEntities>();
            pocketInfoList.ForEach(x =>
            {
               pocketInfoEntityList.Add(MapToBusinessEntity(x));
            });
            return pocketInfoEntityList;
        }

        private PocketInfoEntities MapToBusinessEntity(PocketInfo pocketInfo)
        {
            PocketInfoEntities pocketInfoEntities = MapEntities.Map<PocketInfo, PocketInfoEntities>(pocketInfo);
            pocketInfoEntities.StateName = pocketInfo.StateInfo.StateName;
            pocketInfoEntities.DistrictName = pocketInfo.DistrictInfo.DistrictName;

            pocketInfoEntities.PocketVillageMappingList = MapEntities.MapList<PocketVillageMapping, PocketVillageMappingEntities>(pocketInfo.PocketVillageMappings.ToList());
            pocketInfoEntities.PocketCropMappingList = MapEntities.MapList<PocketCropMapping, PocketCropMappingEntities>(pocketInfo.PocketCropMappings.ToList());
            pocketInfoEntities.PocketFertilizerMappingList = MapEntities.MapList<PocketFertilizerMapping, PocketFertilizerMappingEntities>(pocketInfo.PocketFertilizerMappings.ToList());

            pocketInfoEntities.states.Add(MapEntities.Map<StateInfo, StateInfoEntities>(pocketInfo.StateInfo));
            pocketInfoEntities.districts.Add(MapEntities.Map<DistrictInfo, DistrictInfoEntities>(pocketInfo.DistrictInfo));
            pocketInfoEntities.pocketStatusList.Add(MapEntities.Map<PocketStatu, PocketStatusEntities>(pocketInfo.PocketStatu));
            pocketInfoEntities.pocketStatus = MapEntities.Map<PocketStatu, PocketStatusEntities>(pocketInfo.PocketStatu);

            PocketVillageMapping pocketMappingTemp;
            pocketInfoEntities.PocketVillageMappingList.ForEach(y =>
            {
                pocketMappingTemp = pocketInfo.PocketVillageMappings.Select(r => r).Where(r => r.Id == y.Id).FirstOrDefault();
                y.SubDistrictName = pocketMappingTemp.SubDistrictInfo.SubDistrictName;
                y.VillageName = pocketMappingTemp.VillageInfo.VILLAGE;
                y.subDistricts.Add(MapEntities.Map<SubDistrictInfo, SubDistrictInfoEntities>(pocketMappingTemp.SubDistrictInfo));
                y.villages.Add(MapEntities.Map<VillageInfo, VillageInfoEntities>(pocketMappingTemp.VillageInfo));
            });

            PocketCropMapping pocketCropMappingTemp;
            pocketInfoEntities.PocketCropMappingList.ForEach(y =>
            {
                pocketCropMappingTemp = pocketInfo.PocketCropMappings.Select(r => r).Where(r => r.id == y.id).FirstOrDefault();
                y.CropInfoEntity = MapEntities.Map<CropInfo, CropInfoEntities>(pocketInfo.PocketCropMappings.Select(r => r).Where(r => r.id == y.id).FirstOrDefault().CropInfo);
                y.Crops.Add(y.CropInfoEntity);
            });

            PocketFertilizerMapping pocketFertilizerMappingTemp;
            pocketInfoEntities.PocketFertilizerMappingList.ForEach(y =>
            {
                pocketFertilizerMappingTemp = pocketInfo.PocketFertilizerMappings.Select(r => r).Where(r => r.Id == y.Id).FirstOrDefault();
                y.FertilizerInfoEntity = MapEntities.Map<FertilizerInfo, FertilizerInfoEntities>(pocketInfo.PocketFertilizerMappings.Select(r => r).Where(r => r.Id == y.Id).FirstOrDefault().FertilizerInfo);
                y.Fertilizers.Add(y.FertilizerInfoEntity);
            });
            return pocketInfoEntities;
        }
        private PocketInfoEntities MapToBusinessEntityForUpdate(PocketInfo pocketInfo)
        {
            IStateInfoOperations stateOperations = new StateInfoOperations();
            IDistrictInfoOperations districtOperations = new DistrictInfoOperations();
            IsubDistrictInfoOperations subDistrictOperations = new SubDistrictInfoOperations();
            IVillageInfoOperations villageOperations = new VillageInfoOperations();
            ICropInfoOperations cropOperations = new CropInfoOperations();
            IFertilizerInfoOperations fertilizerOperations = new FertilizerInfoOperations();
            IPocketInfoOperations pocketOperations = new PocketInfoOperations();

            List<CropInfoEntities> crops =MapEntities.MapList<CropInfo,CropInfoEntities>(cropOperations.GetAllCrops().ToList());
            List<FertilizerInfoEntities> fertilizers = MapEntities.MapList<FertilizerInfo, FertilizerInfoEntities>(fertilizerOperations.GetFertilizerList());

            PocketInfoEntities pocketInfoEntities = MapEntities.Map<PocketInfo, PocketInfoEntities>(pocketInfo);
            pocketInfoEntities.StateName = pocketInfo.StateInfo.StateName;
            pocketInfoEntities.DistrictName = pocketInfo.DistrictInfo.DistrictName;

            pocketInfoEntities.PocketVillageMappingList = MapEntities.MapList<PocketVillageMapping, PocketVillageMappingEntities>(pocketInfo.PocketVillageMappings.ToList());
            pocketInfoEntities.PocketCropMappingList = MapEntities.MapList<PocketCropMapping, PocketCropMappingEntities>(pocketInfo.PocketCropMappings.ToList());
            pocketInfoEntities.PocketFertilizerMappingList = MapEntities.MapList<PocketFertilizerMapping, PocketFertilizerMappingEntities>(pocketInfo.PocketFertilizerMappings.ToList());

            pocketInfoEntities.states =MapEntities.MapList<StateInfo, StateInfoEntities>(stateOperations.GetAllStates());
            pocketInfoEntities.districts=MapEntities.MapList<DistrictInfo, DistrictInfoEntities>(districtOperations.GetDistrictListByStateId(pocketInfoEntities.StateID.Value));
            pocketInfoEntities.pocketStatusList = MapEntities.MapList<PocketStatu, PocketStatusEntities>(pocketOperations.GetpocketStatusList());
            pocketInfoEntities.pocketStatus = MapEntities.Map<PocketStatu, PocketStatusEntities>(pocketInfo.PocketStatu);

            PocketVillageMapping pocketMappingTemp;
            pocketInfoEntities.PocketVillageMappingList.ForEach(y =>
            {
                pocketMappingTemp = pocketInfo.PocketVillageMappings.Select(r => r).Where(r => r.Id == y.Id).FirstOrDefault();
                y.SubDistrictName = pocketMappingTemp.SubDistrictInfo.SubDistrictName;
                y.VillageName = pocketMappingTemp.VillageInfo.VILLAGE;
                y.subDistricts = MapEntities.MapList<SubDistrictInfo, SubDistrictInfoEntities>(subDistrictOperations.GetSubDistrictByDistrictId(pocketInfoEntities.DistrictId.Value));
                y.villages = MapEntities.MapList<VillageInfo, VillageInfoEntities>(villageOperations.GetAllVillagesBySubDistrictId(y.SubDistrictId.Value));
            });

            PocketCropMapping pocketCropMappingTemp;
            pocketInfoEntities.PocketCropMappingList.ForEach(y =>
            {
                pocketCropMappingTemp = pocketInfo.PocketCropMappings.Select(r => r).Where(r => r.id == y.id).FirstOrDefault();
                y.CropInfoEntity = MapEntities.Map<CropInfo, CropInfoEntities>(pocketInfo.PocketCropMappings.Select(r => r).Where(r => r.id == y.id).FirstOrDefault().CropInfo);
                y.Crops = crops;

            });

            PocketFertilizerMapping pocketFertilizerMappingTemp;
            pocketInfoEntities.PocketFertilizerMappingList.ForEach(y =>
            {
                pocketFertilizerMappingTemp = pocketInfo.PocketFertilizerMappings.Select(r => r).Where(r => r.Id == y.Id).FirstOrDefault();
                y.FertilizerInfoEntity = MapEntities.Map<FertilizerInfo, FertilizerInfoEntities>(pocketInfo.PocketFertilizerMappings.Select(r => r).Where(r => r.Id == y.Id).FirstOrDefault().FertilizerInfo);
                y.Fertilizers = fertilizers;
            });
            return pocketInfoEntities;
        }

        [HttpGet]
        [Route("GetPocketPageUIvalues")]
        public PocketPageUIvalues GetPocketPageUIvalues()
        {
            PocketPageUIvalues pageUIvalues = new PocketPageUIvalues();
            IStateInfoOperations stateInfo = new StateInfoOperations();
            ICropInfoOperations cropOperations = new CropInfoOperations();
            IFertilizerInfoOperations fertilizerOperation = new FertilizerInfoOperations();
            IPocketInfoOperations pocketInfo = new PocketInfoOperations();
            
            pageUIvalues.states = MapEntities.MapList<StateInfo, StateInfoEntities>(stateInfo.GetAllStates());
            pageUIvalues.crops = MapEntities.MapList<CropInfo, CropInfoEntities>(cropOperations.GetAllCrops().ToList());
            pageUIvalues.fertilizers = MapEntities.MapList<FertilizerInfo, FertilizerInfoEntities>(fertilizerOperation.GetFertilizerList());
            pageUIvalues.pocketStatusList = MapEntities.MapList<PocketStatu, PocketStatusEntities>(pocketInfo.GetpocketStatusList());

            return pageUIvalues;
        }

       
    }
}
