using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
using DataLayer.Interfaces;
namespace DataLayer.Impelmentation
{
    public class FApaymentAgencyOperations:IFApaymentAgencyOperations
    {
        DBentities db = new DBentities();
        public List<FApaymentAgency> GetAllPaymentAgency()
        {
            try
            {
                List<FApaymentAgency> paymentAgencyList = db.FApaymentAgencies.Select(x => x).ToList();
                return paymentAgencyList;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
