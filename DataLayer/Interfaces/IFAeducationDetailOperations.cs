using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
namespace DataLayer.Interfaces
{
    public interface IFAeducationDetailOperations
    {
        IEnumerable<FAeducationDetail> InsertFAeducationDetail(IEnumerable<FAeducationDetail> faEducationDetailList);
        int RemoveEducationDetailForFA(int FAid);
        int UpdateEducationDetailForFA(List<FAeducationDetail> EducationDetailList);

    }
}
