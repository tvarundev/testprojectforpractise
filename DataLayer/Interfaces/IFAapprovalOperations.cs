using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
namespace DataLayer.Interfaces
{
    public interface IFAapprovalOperations
    {
        FAapproval InsertFAapproval(FAapproval faApproval);
        int RemoveApprovalDetailForFA(int FAid);
        int UpdateApprovalForFA(List<FAapproval> ApprovalList);
    }
}
