using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
namespace DataLayer.Interfaces
{
    public interface IfarmerDetailOperations
    {
        FarmerDetail GetFarmerDetailById(int farmerDetailId);
        FarmerDetail GetFarmerDetailByFirstName(string firstName);
        IEnumerable<FarmerDetail> GetFarmerDetailList();
        FarmerDetail InsertFarmerDetail(FarmerDetail farmerDetail);
        FarmerDetail UpdateFarmerDetail(FarmerDetail farmerDetail);
        int DeleteFarmerDetail(int farmerDetailId);
    }
}
