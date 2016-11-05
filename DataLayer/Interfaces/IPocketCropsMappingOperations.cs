using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
namespace DataLayer.Interfaces
{
    public interface IPocketCropsMappingOperations
    {
        List<PocketCropMapping> GetCropsByPocket(int pocketId);
        int UpdateCropsOfPocket(List<PocketCropMapping> pocketCropsMappingList);
        int InsertCropsOfPocket(List<PocketCropMapping> pocketCropsMappingList);
        int DeleteCropsOfPocket(List<PocketCropMapping> pocketCropsMappingList);

    }
}
