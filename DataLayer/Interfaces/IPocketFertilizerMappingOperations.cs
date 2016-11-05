using DataLayer.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IPocketFertilizerMappingOperations
    {
         List<PocketFertilizerMapping> GetFertilizerByPocket(int pocketId);
         int UpdateFertilizersOfPocket(List<PocketFertilizerMapping> pocketFertilizersMappingList);
         int InsertFertilizersOfPocket(List<PocketFertilizerMapping> pocketFertilizersMappingList);
         int DeleteFertilizerOfPocket(List<PocketFertilizerMapping> pocketFertilizersMappingList);
    }
}
