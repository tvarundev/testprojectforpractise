using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
using DataLayer.Interfaces;
namespace DataLayer.Impelmentation
{
    public class FarmerConsumptionOperation : IFarmerConsumptionOperation
    {
        DBentities db = new DBentities();
        public List<FarmerConsumption> GetFarmerConsumptionList()
        {
            try
            {
                List<FarmerConsumption> farmerConsumptionList = db.FarmerConsumptions.Select(x => x).ToList();
                return farmerConsumptionList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
