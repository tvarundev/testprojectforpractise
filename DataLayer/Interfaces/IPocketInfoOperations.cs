using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
namespace DataLayer.Interfaces
{
    public interface IPocketInfoOperations
    {
        List<PocketInfo> GetPocketList();
        List<PocketInfo> GetPocketList(int pocketStatusId);
        List<PocketInfo> GetAllActivePocketListByDistrictId(int districtId, int pocketStatusId);
        int InsertPocket(PocketInfo pocketInfo);
        PocketInfo GetPockeById(int pocketId);
        int UpdatePocket(PocketInfo pocketInfo);
        int UpdadteStatusOfPocket(int pocketId, int statusId);
        int DeletePocket(int pocketId);
        List<PocketStatu> GetpocketStatusList();
    }
}
