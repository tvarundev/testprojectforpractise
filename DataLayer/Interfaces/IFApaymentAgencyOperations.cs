using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
namespace DataLayer.Interfaces
{
    public interface IFApaymentAgencyOperations
    {
        List<FApaymentAgency> GetAllPaymentAgency();
    }
}
