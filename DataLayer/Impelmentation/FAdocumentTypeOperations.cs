using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using DataLayer.DBContext;
namespace DataLayer.Impelmentation
{
    public class FAdocumentTypeOperations:IFAdocumentTypeOperations
    {
        DBentities db = new DBentities();


        public IEnumerable<FAdocumentType> GetFAdocumentTypeList()
        {
            try
            {
                return db.FAdocumentTypes.Select(x => x);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
