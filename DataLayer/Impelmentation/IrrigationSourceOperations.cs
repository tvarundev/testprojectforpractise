using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
using DataLayer.Interfaces;
namespace DataLayer.Impelmentation
{
    public class IrrigationSourceOperations:IirrigationSourceOperations
    {
        DBentities db = new DBentities();
        public List<IrrigationSource> GetAllIrrigationSources()
        {
            try
            {
                List<IrrigationSource> irrigationSourceList = db.IrrigationSources.Select(x => x).ToList();
                return irrigationSourceList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
