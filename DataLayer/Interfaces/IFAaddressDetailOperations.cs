using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
namespace DataLayer.Interfaces
{
    public interface IFAaddressDetailOperations
    {
        int InsertFAAddressDetail(FAaddressDetail faAddressDetail);
        int RemoveFAaddressDetail(int FAid);
        int UpdateFAaddressDetail(List<FAaddressDetail> addressDetailList);
    }
}
