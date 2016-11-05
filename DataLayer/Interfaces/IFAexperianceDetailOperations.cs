using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
namespace DataLayer.Interfaces
{
    public interface IFAexperianceDetailOperations
    {
        IEnumerable<FAexperianceDetail> InsertFAexperienceDetail(IEnumerable<FAexperianceDetail> faExperienceDetailList);
        int RemoveExperienceDetailForFA(int FAid);

        int UpdateExperienceDetailForFA(List<FAexperianceDetail> faExperienceDetailList);
    }
}
