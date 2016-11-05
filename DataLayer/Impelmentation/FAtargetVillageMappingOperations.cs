using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using DataLayer.DBContext;
namespace DataLayer.Impelmentation
{
    public class FAtargetVillageMappingOperations:IFAtargetVillageMappingOperations
    {
        DBentities db = new DBentities();
        public IEnumerable<FAtargetVillageMapping> InsertFAtargetVillageMapping(IEnumerable<FAtargetVillageMapping> targetVillageMappingList)
        {
            try
            {
                db.FAtargetVillageMappings.AddRange(targetVillageMappingList);
                db.SaveChanges();
                return targetVillageMappingList;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }


        public int RemoveFAtargetVillageMappingOfTraget(int TargetId)
        {
            try
            {
                List<FAtargetVillageMapping> TargetVillageMappingList = db.FAtargetVillageMappings.Select(x => x).Where(x => x.TargetId == TargetId).ToList();
                if(TargetVillageMappingList.Count()>0)
                {
                    foreach(var targetMapping in TargetVillageMappingList)
                    {
                        db.FAtargetVillageMappings.Remove(targetMapping);
                    }
                }
               return db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int UpdateFAtargetVillageMappingOfTarget(List<FAtargetVillageMapping> targetVillageMappingList)
        {
            try
            {
                int faId = targetVillageMappingList.ElementAt(0).TargetId.Value;
                List<FAtargetVillageMapping> ExistingTargetMappingList = db.FAtargetVillageMappings.Select(x => x).Where(x => x.TargetId.Value == faId).ToList();

                List<FAtargetVillageMapping> TargetVillageListToAdd = new List<FAtargetVillageMapping>();
                List<FAtargetVillageMapping> TargetVillageListToUpdate = new List<FAtargetVillageMapping>();
                List<FAtargetVillageMapping> TargetVillageListToDelete = new List<FAtargetVillageMapping>();

                foreach (var targetMapping in targetVillageMappingList)
                {
                    FAtargetVillageMapping newTargetMapping = ExistingTargetMappingList.Select(x => x).Where(x => x.Id == targetMapping.Id).FirstOrDefault();
                    if (newTargetMapping == null)
                    {
                        TargetVillageListToAdd.Add(targetMapping);
                    }
                    else
                    {
                        TargetVillageListToUpdate.Add(targetMapping);
                    }
                }
                foreach (var targetVillage in ExistingTargetMappingList)
                {
                    FAtargetVillageMapping existingTargetMapping = targetVillageMappingList.Select(x => x).Where(x => x.Id == targetVillage.Id).FirstOrDefault();
                    if (existingTargetMapping == null)
                    {
                        TargetVillageListToDelete.Add(targetVillage);
                    }
                }

                InsertFAtargetVillageMapping(TargetVillageListToAdd);

                foreach (var targetVillage in TargetVillageListToDelete)
                {
                    //RemoveFAtargetVillageMappingOfTraget(targetVillage.Id);
                    FAtargetVillageMapping trgvlgmap = db.FAtargetVillageMappings.Select(x => x).Where(x => x.Id == targetVillage.Id).FirstOrDefault();
                    db.FAtargetVillageMappings.Remove(trgvlgmap);
                }
                FAtargetVillageMapping targetVillageToUpdate;
                foreach (var targetVillage in TargetVillageListToUpdate)
                {
                    targetVillageToUpdate = ExistingTargetMappingList.Select(x => x).Where(x => x.Id == targetVillage.Id).FirstOrDefault();
                    if (targetVillageToUpdate != null)
                    {
                        targetVillageToUpdate.CropId = targetVillage.CropId;
                        targetVillageToUpdate.FromDate = targetVillage.FromDate;
                        targetVillageToUpdate.NoOfDemos = targetVillage.NoOfDemos;
                        targetVillageToUpdate.NoOfFarmerMeetings = targetVillage.NoOfFarmerMeetings;
                        targetVillageToUpdate.NoOfPrescriptions = targetVillage.NoOfPrescriptions;
                        targetVillageToUpdate.NoOfSamples = targetVillage.NoOfSamples;
                        targetVillageToUpdate.ToDate = targetVillage.ToDate;
                        targetVillageToUpdate.TotalMonths = targetVillage.TotalMonths;
                    }
                }
                return db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
