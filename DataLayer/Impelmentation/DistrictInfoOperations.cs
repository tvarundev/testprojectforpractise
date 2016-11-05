using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using DataLayer.DBContext;
namespace DataLayer.Impelmentation
{
    public class DistrictInfoOperations : IDistrictInfoOperations
    {
        DBentities db = new DBentities();
        public IEnumerable<DistrictInfo> GetAllDistricts()
        {
            try
            {
                IEnumerable<DistrictInfo> districtList = db.DistrictInfoes.Select(x => x);
                return districtList;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }


        public List<DistrictInfo> GetDistrictListByStateId(int stateId)
        {
            try
            {
                List<DistrictInfo> DistrictList = db.DistrictInfoes.Select(x => x).Where(x => x.StateID == stateId).ToList();
                return DistrictList;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
