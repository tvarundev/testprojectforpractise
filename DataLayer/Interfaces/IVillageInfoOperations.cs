using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
namespace DataLayer.Interfaces
{
    public interface IVillageInfoOperations
    {
        List<VillageInfo> GetAllVillagesBySubDistrictId(int subDistrictId);
        List<VillageInfo> GetAllVillages();
        List<VillageInfo> GetVillageListOfPocket(int pocketId);
    }
}
