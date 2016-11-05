using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
using DataLayer.Interfaces;
namespace DataLayer.Impelmentation
{
    public class CropInfoOperations:ICropInfoOperations
    {
        DBentities db = new DBentities();
        
        public IEnumerable<CropInfo> GetAllCrops()
        {
            try
            {
                IEnumerable<CropInfo> cropInfoList = db.CropInfoes.Select(x => x);
                return cropInfoList;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public CropInfo GetCropInfoById(int id)
        {
            try
            {
                CropInfo cropInfo = db.CropInfoes.Select(x => x).Where(x => x.CropID == id).FirstOrDefault();
                return cropInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public CropInfo GetCropInfoByName(string cropName)
        {
            try
            {
                CropInfo cropInfo = db.CropInfoes.Select(x => x).Where(x => x.CropName == cropName).FirstOrDefault();
                return cropInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public List<CropInfo> GetCropListOfPocket(int pocketId)
        {
            try
            {
                List<PocketCropMapping> pocketCropMappingList = db.PocketCropMappings.Select(x => x).Where(x => x.PocketId == pocketId).ToList();
                List<CropInfo> cropList = new List<CropInfo>();
                foreach(var cropMapping in pocketCropMappingList)
                {
                    cropList.Add(cropMapping.CropInfo);
                }
                return cropList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
