using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
namespace DataLayer.Interfaces
{
    public interface ICropInfoOperations
    {
        IEnumerable<CropInfo> GetAllCrops();
        CropInfo GetCropInfoById(int id);
        CropInfo GetCropInfoByName(string cropName);

        List<CropInfo> GetCropListOfPocket(int pocketId);
    }
}
