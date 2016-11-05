using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using DataLayer.DBContext;
namespace DataLayer.Impelmentation
{
    public class VillageInfoOperations : IVillageInfoOperations
    {
        DBentities db = new DBentities();
        public List<VillageInfo> GetAllVillagesBySubDistrictId(int subDistrictId)
        {
            try
            {
                List<VillageInfo> villageList = db.VillageInfoes.Select(x => x).Where(y => y.SubDistID == subDistrictId).ToList();
                return villageList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<VillageInfo> GetAllVillages()
        {
            try
            {
                var villageListTemp = db.VillageInfoes.Select(x => new { x.VillageID,x.VILLAGE,x.CDBLOCKN}).ToList();
                List<VillageInfo> villageList = new List<VillageInfo>();
                VillageInfo villageInfo;
                foreach(var village in villageListTemp)
                {
                    villageInfo = new VillageInfo();
                    villageInfo.VillageID = village.VillageID;
                    villageInfo.VILLAGE = village.VILLAGE;
                    villageInfo.CDBLOCKN = village.CDBLOCKN;
                    villageList.Add(villageInfo);
                }
                return villageList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public List<VillageInfo> GetVillageListOfPocket(int pocketId)
        {
            List<PocketVillageMapping> pocketVillageMappingList = db.PocketVillageMappings.Select(x => x).Where(x => x.PocketId == pocketId).ToList();

            List<VillageInfo> villageList = new List<VillageInfo>();
            foreach(var mapping in pocketVillageMappingList)
            {
                villageList.Add(mapping.VillageInfo);
            }
            return villageList;
        }
    }
}
