using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
using DataLayer.Interfaces;
namespace DataLayer.Impelmentation
{
    public class PocketVillageMappingOperations : IPocketVillageMappingOperations
    {
        DBentities db = new DBentities();
        public PocketVillageMapping GetPocketVillageMappingOfPocket(int pocketVillageMappingId)
        {
            try
            {
                PocketVillageMapping pocketMapping = db.PocketVillageMappings.Select(x => x).Where(x => x.Id == pocketVillageMappingId).FirstOrDefault();
                return pocketMapping;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<PocketVillageMapping> GetPocketVillageMappingListOfPocket(int pocketId)
        {
            try
            {
                List<PocketVillageMapping> pocketMappingList = db.PocketVillageMappings.Select(x => x).Where(x => x.PocketId == pocketId).ToList();
                return pocketMappingList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int DeletePocketVillageMappingListOfPocket(int pocketId)
        {
            try
            {
                List<PocketVillageMapping> pocketMappingList = db.PocketVillageMappings.Select(x => x).Where(x => x.PocketId == pocketId).ToList();
                return DeletePocketVillageMappingListOfPocket(pocketMappingList);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int DeletePocketVillageMappingListOfPocket(List<PocketVillageMapping> pocketVillageMappingList)
        {
            PocketVillageMapping pocketMapping = null;
            pocketVillageMappingList.ForEach(y =>
            {
                pocketMapping = db.PocketVillageMappings.Select(x => x).Where(x => x.Id == y.Id).FirstOrDefault();
                db.PocketVillageMappings.Remove(pocketMapping);
            });
            return db.SaveChanges();
        }
        public int UpdatePocketVillageMappingOfPocket(List<PocketVillageMapping> pocketVillageMappingList)
        {
            try
            {
                List<PocketVillageMapping> ExistingList = GetPocketVillageMappingListOfPocket(pocketVillageMappingList.ElementAt(0).PocketId.Value).ToList();

                List<PocketVillageMapping> villageMappingToUpdate = pocketVillageMappingList.Select(x => x).Where(x => x.Id > 0).ToList();
                List<PocketVillageMapping> villageMappingToInsert = pocketVillageMappingList.Select(x => x).Where(x => x.Id == 0).ToList();
                List<PocketVillageMapping> villageMappingToDelete = ExistingList.Select(x => x).Where(x => !pocketVillageMappingList.Select(y=>y.Id).Contains(x.Id)).ToList();

                InsertPocketVillageMappingOfPocket(villageMappingToInsert);
                DeletePocketVillageMappingListOfPocket(villageMappingToDelete);

                PocketVillageMapping pocketMapping = null;
                villageMappingToUpdate.ForEach(y =>
                {
                    pocketMapping = db.PocketVillageMappings.Select(x => x).Where(x => x.Id == y.Id).FirstOrDefault();
                    if(pocketMapping!=null)
                    {
                        pocketMapping.IsActive = y.IsActive;
                        pocketMapping.PocketId = y.PocketId;
                        pocketMapping.SubDistrictId = y.SubDistrictId;
                        pocketMapping.UpdatedDate = DateTime.Now;
                        pocketMapping.VillageId = y.VillageId;
                    }
                    
                });

                return db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public int InsertPocketVillageMappingOfPocket(List<PocketVillageMapping> pocketVillageMappingList)
        {
            try
            {
                pocketVillageMappingList.ForEach(x =>
                {
                    x.CreatedDate = DateTime.Now;
                    x.UpdatedDate = DateTime.Now;
                    x.IsActive = true;
                    db.PocketVillageMappings.Add(x);
                });
                return db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



    }
}
