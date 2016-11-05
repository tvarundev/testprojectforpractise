using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
using DataLayer.Interfaces;
namespace DataLayer.Impelmentation
{
    public class SubDistrictInfoOperations:IsubDistrictInfoOperations
    {
        DBentities db = new DBentities();
        public List<SubDistrictInfo> GetSubDistrictByDistrictId(int districtId)
        {
            try
            {

                List<SubDistrictInfo> subDistrictInfoList = db.SubDistrictInfoes.Select(x => x).Where(y => y.DistrictID == districtId).ToList();
                return subDistrictInfoList;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }


        public List<SubDistrictInfo> GetAllSubDistrictList()
        {
            try
            {
                List<SubDistrictInfo> subDistrictList = db.SubDistrictInfoes.Select(x => x).ToList();
                return subDistrictList;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
