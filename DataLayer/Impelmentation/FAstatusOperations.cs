using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
using DataLayer.Interfaces;
namespace DataLayer.Impelmentation
{
    public class FAstatusOperations:IFAstatusOperations
    {
        DBentities db = new DBentities();
        public IEnumerable<FAStatu> GetFAStatusList()
        {
            try
            {
                List<FAStatu> statusList = db.FAStatus.Select(x => x).ToList();
                return statusList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
