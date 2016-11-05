using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using DataLayer.DBContext;
namespace DataLayer.Impelmentation
{
    public class PocketInfoOperations : IPocketInfoOperations
    {
        DBentities db = new DBentities();
        public List<PocketInfo> GetPocketList()
        {
            try
            {
                List<PocketInfo> pocketInfo = db.PocketInfoes.Select(x => x).ToList();
                return pocketInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<PocketInfo> GetPocketList(int pocketStatusId)
        {
            try
            {
                List<PocketInfo> pocketInfo = db.PocketInfoes.Select(x => x).Where(x => x.PocketStatusId == pocketStatusId).ToList();
                return pocketInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<PocketInfo> GetAllActivePocketListByDistrictId(int districtId, int pocketStatusId)
        {
            try
            {
                List<PocketInfo> pocketInfo = db.PocketInfoes.Select(x => x).Where(x => x.DistrictId == districtId && x.StateID == pocketStatusId).ToList();
                return pocketInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int InsertPocket(PocketInfo pocketInfo)
        {
            pocketInfo.CreatedDate = DateTime.Now;
            pocketInfo.UpdatedDate = DateTime.Now;
            pocketInfo.CreatedBy = pocketInfo.CreatedBy;
            db.PocketInfoes.Add(pocketInfo);
            db.SaveChanges();
            return pocketInfo.PocketID;
        }


        public PocketInfo GetPockeById(int pocketId)
        {
            PocketInfo pocketInfo = db.PocketInfoes.Select(x => x).Where(x => x.PocketID == pocketId).FirstOrDefault();
            return pocketInfo;
        }

        public int UpdatePocket(PocketInfo pocketInfo)
        {
            PocketInfo pocketInfoToUpdate = GetPockeById(pocketInfo.PocketID);
            pocketInfoToUpdate.PocketStatusId = pocketInfo.PocketStatusId;
            pocketInfoToUpdate.DistrictId = pocketInfo.DistrictId;
            pocketInfoToUpdate.PocketName = pocketInfo.PocketName;
            pocketInfoToUpdate.StateID = pocketInfo.StateID;
            pocketInfoToUpdate.UpdatedDate = DateTime.Now;
            pocketInfoToUpdate.UpdatedBy = pocketInfo.UpdatedBy;
            return db.SaveChanges();
        }

        public int DeletePocket(int pocketId)
        {
            PocketInfo pocketInfoToDelete = GetPockeById(pocketId);
            db.PocketInfoes.Remove(pocketInfoToDelete);
            return db.SaveChanges();
        }
        public int UpdadteStatusOfPocket(int pocketId, int statusId)
        {
            PocketInfo pocketInfoToChangeStatus = GetPockeById(pocketId);
            pocketInfoToChangeStatus.PocketStatusId = statusId;
            return UpdatePocket(pocketInfoToChangeStatus);
        }

        public List<PocketStatu> GetpocketStatusList()
        {
            List<PocketStatu> pocketStatusList = db.PocketStatus.Select(x => x).ToList();
            return pocketStatusList;
        }
    }
}
