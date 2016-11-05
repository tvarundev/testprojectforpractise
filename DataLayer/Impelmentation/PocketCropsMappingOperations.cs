using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
using DataLayer.Interfaces;
namespace DataLayer.Impelmentation
{
    public class PocketCropsMappingOperations : IPocketCropsMappingOperations
    {
        DBentities db = new DBentities();
        public List<PocketCropMapping> GetCropsByPocket(int pocketId)
        {
            List<PocketCropMapping> PocketCrops = db.PocketCropMappings.Select(x => x).Where(x => x.PocketId == pocketId).ToList();
            return PocketCrops;
        }

        public int UpdateCropsOfPocket(List<PocketCropMapping> pocketCropsMappingList)
        {
            List<PocketCropMapping> ExistingList = GetCropsByPocket(pocketCropsMappingList.ElementAt(0).PocketId.Value).ToList();

            List<PocketCropMapping> CropsMappingToUpdate = pocketCropsMappingList.Select(x => x).Where(x => x.id > 0).ToList();
            List<PocketCropMapping> CropsMappingToInsert = pocketCropsMappingList.Select(x => x).Where(x => x.id == 0).ToList();
            List<PocketCropMapping> CropsMappingToDelete = ExistingList.Select(x => x).Where(x => !pocketCropsMappingList.Select(y => y.id).Contains(x.id)).ToList();
            

            InsertCropsOfPocket(CropsMappingToInsert);
            DeleteCropsOfPocket(CropsMappingToDelete);

            PocketCropMapping pocketCropsMapping = null;
            CropsMappingToUpdate.ForEach(y =>
            {
                pocketCropsMapping = db.PocketCropMappings.Select(x => x).Where(x => x.id == y.id).FirstOrDefault();
                if (pocketCropsMapping != null)
                {
                    pocketCropsMapping.CropId = y.CropId;
                    pocketCropsMapping.PocketId = y.PocketId;
                }
            });

            return db.SaveChanges();
        }

        public int InsertCropsOfPocket(List<PocketCropMapping> pocketCropsMappingList)
        {
            foreach (var pocketCrop in pocketCropsMappingList)
            {
                db.PocketCropMappings.Add(pocketCrop);
            }
            return db.SaveChanges();
        }

        public int DeleteCropsOfPocket(List<PocketCropMapping> pocketCropsMappingList)
        {
            foreach (var pocketCrop in pocketCropsMappingList)
            {
                db.PocketCropMappings.Remove(pocketCrop);
            }
            return db.SaveChanges();
        }
    }
}
