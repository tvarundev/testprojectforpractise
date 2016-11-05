using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
namespace DataLayer.Interfaces
{
    public interface IPocketVillageMappingOperations
    {
        PocketVillageMapping GetPocketVillageMappingOfPocket(int pocketVillageMappingId);
        List<PocketVillageMapping> GetPocketVillageMappingListOfPocket(int pocketId);
        int DeletePocketVillageMappingListOfPocket(int pocketId);
        int DeletePocketVillageMappingListOfPocket(List<PocketVillageMapping> pocketVillageMappingList);
        int UpdatePocketVillageMappingOfPocket(List<PocketVillageMapping> pocketVillageMappingList);
        int InsertPocketVillageMappingOfPocket(List<PocketVillageMapping> pocketVillageMappingList);


    }
}
