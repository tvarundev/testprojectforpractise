using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
using DataLayer.Interfaces;
namespace DataLayer.Impelmentation
{
    public class FaApprovedByOperations:IFaApprovedByOperations
    {
        DBentities db = new DBentities();
        public List<FAapprovedBy> GetApprovedByList()
        {
            List<FAapprovedBy> approvedByList = db.FAapprovedBies.Select(x => x).ToList();
            return approvedByList;
        }
    }
}
