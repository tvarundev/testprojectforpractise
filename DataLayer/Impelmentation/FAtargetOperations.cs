using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
using DataLayer.Interfaces;
namespace DataLayer.Impelmentation
{
    public class FAtargetOperations:IFAtargetOperations
    {
        DBentities db = new DBentities();
        public IEnumerable<FAtargetDetail> InsertTargetsForFA(IEnumerable<FAtargetDetail> faTargetDetailList)
        {
            try
            {
                foreach(var targetDetail in faTargetDetailList)
                {
                    db.FAtargetDetails.Add(targetDetail);
                }
                db.SaveChanges();
                return faTargetDetailList;

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }


        public int InsertTargetsForFA(FAtargetDetail faTargetDetail)
        {
            try
            {
                db.FAtargetDetails.Add(faTargetDetail);
                db.SaveChanges();
                return faTargetDetail.Id;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public int RemoveTargetsForFA(int FAid)
        {
            try
            {
                IFAtargetVillageMappingOperations targetMappingOperations = new FAtargetVillageMappingOperations();
                List<FAtargetDetail> targetDetailList = db.FAtargetDetails.Select(x => x).Where(x => x.FAid == FAid).ToList();
                if(targetDetailList.Count>0)
                {
                    foreach(var targetDetail in targetDetailList)
                    {
                        targetMappingOperations.RemoveFAtargetVillageMappingOfTraget(targetDetail.Id);
                        db.FAtargetDetails.Remove(targetDetail);
                    }
                }
                return db.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        

        public int UpdateTargetForFA(List<FAtargetDetail> targetDetailList)
        {
            try
            {
                int faId = targetDetailList.ElementAt(0).FAid.Value;
                List<FAtargetDetail> ExistingTargetList = db.FAtargetDetails.Select(x => x).Where(x => x.FAid.Value == faId).ToList();

                List<FAtargetDetail> TargetListToAdd = new List<FAtargetDetail>();
                List<FAtargetDetail> TargetListToUpdate = new List<FAtargetDetail>();
                List<FAtargetDetail> TargetListToDelete = new List<FAtargetDetail>();
                IFAtargetVillageMappingOperations targetVillageMappingOperation = new FAtargetVillageMappingOperations();

                foreach (var target in targetDetailList)
                {
                    FAtargetDetail newTarget = ExistingTargetList.Select(x => x).Where(x => x.Id == target.Id).FirstOrDefault();
                    if (newTarget == null)
                    {
                        TargetListToAdd.Add(target);
                    }
                    else
                    {
                        TargetListToUpdate.Add(target);
                    }
                }
                foreach (var target in ExistingTargetList)
                {
                    FAtargetDetail existingTarget = targetDetailList.Select(x => x).Where(x => x.Id == target.Id).FirstOrDefault();
                    if (existingTarget == null)
                    {
                        TargetListToDelete.Add(target);
                    }
                }

                InsertTargetsForFA(TargetListToAdd);

                foreach (var target in TargetListToDelete)
                {
                    targetVillageMappingOperation.RemoveFAtargetVillageMappingOfTraget(target.Id);

                    FAtargetDetail trgtDtl = db.FAtargetDetails.Select(x => x).Where(x => x.Id == target.Id).FirstOrDefault();
                    db.FAtargetDetails.Remove(trgtDtl);
                    //RemoveTargetsForFA(target.Id);
                }
                FAtargetDetail targetToUpdate;
                foreach (var target in TargetListToUpdate)
                {
                    targetToUpdate = ExistingTargetList.Select(x => x).Where(x => x.Id == target.Id).FirstOrDefault();
                    if (targetToUpdate != null)
                    {
                        targetToUpdate.DealerId = target.DealerId;
                        targetToUpdate.VillageId = target.VillageId;
                        targetVillageMappingOperation.UpdateFAtargetVillageMappingOfTarget(target.FAtargetVillageMappings.ToList());
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
