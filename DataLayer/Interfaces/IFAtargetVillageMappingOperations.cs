using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
namespace DataLayer.Interfaces
{
    public interface IFAtargetVillageMappingOperations
    {
        IEnumerable<FAtargetVillageMapping> InsertFAtargetVillageMapping(IEnumerable<FAtargetVillageMapping> targetVillageMappingList);
        int RemoveFAtargetVillageMappingOfTraget(int TargetId);
        int UpdateFAtargetVillageMappingOfTarget(List<FAtargetVillageMapping> targetVillageMappingList);
    }
}
