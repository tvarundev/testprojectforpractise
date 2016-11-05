using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using DataLayer.DBContext;
namespace DataLayer.Impelmentation
{
    public class PocketFertilizerMappingOperations:IPocketFertilizerMappingOperations
    {
        DBentities db = new DBentities();
        public List<PocketFertilizerMapping> GetFertilizerByPocket(int pocketId)
        {
            List<PocketFertilizerMapping> PocketFertilizers = db.PocketFertilizerMappings.Select(x => x).Where(x => x.PocketId == pocketId).ToList();
            return PocketFertilizers;
        }

        public int UpdateFertilizersOfPocket(List<PocketFertilizerMapping> pocketFertilizersMappingList)
        {
            List<PocketFertilizerMapping> ExistingList = GetFertilizerByPocket(pocketFertilizersMappingList.ElementAt(0).PocketId.Value).ToList();

            List<PocketFertilizerMapping> CropsMappingToUpdate = pocketFertilizersMappingList.Select(x => x).Where(x => x.Id > 0).ToList();
            List<PocketFertilizerMapping> CropsMappingToInsert = pocketFertilizersMappingList.Select(x => x).Where(x => x.Id == 0).ToList();
            List<PocketFertilizerMapping> CropsMappingToDelete = ExistingList.Select(x => x).Where(x => !pocketFertilizersMappingList.Select(y => y.Id).Contains(x.Id)).ToList();

            InsertFertilizersOfPocket(CropsMappingToInsert);
            DeleteFertilizerOfPocket(CropsMappingToDelete);

            PocketFertilizerMapping pocketFertilizerMapping = null;
            CropsMappingToUpdate.ForEach(y =>
            {
                pocketFertilizerMapping = db.PocketFertilizerMappings.Select(x => x).Where(x => x.Id == y.Id).FirstOrDefault();
                if (pocketFertilizerMapping != null)
                {
                    pocketFertilizerMapping.FertilizerId = y.FertilizerId;
                    pocketFertilizerMapping.PocketId = y.PocketId;
                }
            });

            return db.SaveChanges();
        }

        public int InsertFertilizersOfPocket(List<PocketFertilizerMapping> pocketFertilizersMappingList)
        {
            foreach (var pocketFertilizer in pocketFertilizersMappingList)
            {
                db.PocketFertilizerMappings.Add(pocketFertilizer);
            }
            return db.SaveChanges();
        }

        public int DeleteFertilizerOfPocket(List<PocketFertilizerMapping> pocketFertilizersMappingList)
        {
            foreach (var pocketFertilizer in pocketFertilizersMappingList)
            {
                db.PocketFertilizerMappings.Remove(pocketFertilizer);
            }
            return db.SaveChanges();
        }
    }
}
