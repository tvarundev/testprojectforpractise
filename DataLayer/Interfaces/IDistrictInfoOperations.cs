using DataLayer.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IDistrictInfoOperations
    {
        IEnumerable<DistrictInfo> GetAllDistricts();
        List<DistrictInfo> GetDistrictListByStateId(int stateId);
    }
}
