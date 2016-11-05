using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
using DataLayer.Interfaces;
namespace DataLayer.Impelmentation
{
    public class FAdesignationOperations:IFAdesignationOperations
    {
        DBentities db = new DBentities();
        public IEnumerable<FAdesignation> GetFAdesignationList()
        {
            try
            {
                return db.FAdesignations.Select(x => x);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
