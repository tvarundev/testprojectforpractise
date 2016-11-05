using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
namespace DataLayer.Interfaces
{
    public interface IFAdetailOperations
    {
        int InsertFAdetail(FAdetail faDetail);
        List<FAdetail> GetFAdetailList();
        FAdetail GetFAdetailById(int id);
        int RemoveFAdetail(int FAid);
        int UpdateFAdetail(FAdetail faDetail);

    }
}
