using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
namespace DataLayer.Interfaces
{
    public interface IFAtargetOperations
    {
        IEnumerable<FAtargetDetail> InsertTargetsForFA(IEnumerable<FAtargetDetail> faTargetDetailList);
        int InsertTargetsForFA(FAtargetDetail faTargetDetail);
        int RemoveTargetsForFA(int FAid);

        int UpdateTargetForFA(List<FAtargetDetail> targetDetailList);
    }
}
