using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
using DataLayer.Interfaces;
namespace DataLayer.Impelmentation
{
    public class DealerDetailOperations:IDealerDetailOperations
    {
        DBentities db = new DBentities();
        public List<DealerDetail> GetAllDealerList()
        {
            try
            {
                List<DealerDetail> DealerDetailList = db.DealerDetails.Select(x => x).ToList();
                return DealerDetailList;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
