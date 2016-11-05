using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
using DataLayer.Interfaces;
namespace DataLayer.Impelmentation
{
    public class FertilizerInfoOperations : IFertilizerInfoOperations
    {
        DBentities db = new DBentities();
        public FertilizerInfo GetFertilizerById(int id)
        {
            FertilizerInfo Fertilizer = db.FertilizerInfoes.Select(x => x).Where(x => x.Id == id).FirstOrDefault();
            return Fertilizer;
        }

        public List<FertilizerInfo> GetFertilizerList()
        {
            List<FertilizerInfo> FertilizerList = db.FertilizerInfoes.Select(x => x).ToList();
            return FertilizerList;
        }
    }
}
