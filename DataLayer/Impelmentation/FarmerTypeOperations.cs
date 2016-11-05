using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using DataLayer.DBContext;
namespace DataLayer.Impelmentation
{
    public class FarmerTypeOperations:IfarmerTypeOperations
    { 
        DBentities db = new DBentities();
        public IEnumerable<FarmerTypeDetail> GetAllFarmerType()
        {
            try
            {
                IEnumerable<FarmerTypeDetail> farmerTypeList = db.FarmerTypeDetails.Select(x => x);
                return farmerTypeList;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
