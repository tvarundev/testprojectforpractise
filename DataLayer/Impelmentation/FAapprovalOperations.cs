using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
using DataLayer.Interfaces;
namespace DataLayer.Impelmentation
{
    public class FAapprovalOperations:IFAapprovalOperations
    {
        DBentities db = new DBentities();
        public FAapproval InsertFAapproval(FAapproval faApproval)
        {
            try
            {
                db.FAapprovals.Add(faApproval);
                db.SaveChanges();
                return faApproval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int RemoveApprovalDetailForFA(int FAid)
        {
            try
            {
                List<FAapproval> ApprovalList = db.FAapprovals.Select(x => x).Where(x => x.FAid == FAid).ToList();
                if(ApprovalList.Count()>0)
                {
                    foreach(var approvalItem in ApprovalList)
                    {
                        db.FAapprovals.Remove(approvalItem);
                    }
                }
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int UpdateApprovalForFA(List<FAapproval> ApprovalList)
        {

            try
            {
                int faId = ApprovalList.ElementAt(0).FAid.Value;
                List<FAapproval> ExistingApprovalList  = db.FAapprovals.Select(x => x).Where(x => x.FAid.Value == faId).ToList();
                
                List<FAapproval> ApprovalListToAdd = new List<FAapproval>();
                List<FAapproval> ApprovalListToUpdate = new List<FAapproval>();
                List<FAapproval> ApprovalListToDelete = new List<FAapproval>();

                foreach (var approval in ApprovalList)
                {
                    FAapproval newApproval = ExistingApprovalList.Select(x => x).Where(x => x.Id == approval.Id).FirstOrDefault();
                    if (newApproval == null)
                    {
                        ApprovalListToAdd.Add(approval);
                    }
                    else
                    {
                        ApprovalListToUpdate.Add(approval);
                    }
                }
                foreach (var approval in ExistingApprovalList)
                {
                    FAapproval existingApproval = ApprovalList.Select(x => x).Where(x => x.Id == approval.Id).FirstOrDefault();
                    if (existingApproval == null)
                    {
                        ApprovalListToDelete.Add(approval);
                    }
                }

                foreach (var approval in ApprovalListToAdd)
                {
                    InsertFAapproval(approval);
                }
                foreach (var approval in ApprovalListToDelete)
                {
                    //RemoveApprovalDetailForFA(approval.Id);
                    FAapproval apprvl = db.FAapprovals.Select(x => x).Where(x => x.Id == approval.Id).FirstOrDefault();
                    db.FAapprovals.Remove(apprvl);

                }
                FAapproval approvalToUpdate;
                foreach (var approval in ApprovalListToUpdate)
                {
                    approvalToUpdate = ExistingApprovalList.Select(x => x).Where(x => x.Id == approval.Id).FirstOrDefault();
                    if (approvalToUpdate != null)
                    {
                        approvalToUpdate.FAApprovedId = approval.FAApprovedId;
                        approvalToUpdate.PocketId = approval.PocketId;
                        approvalToUpdate.RecommandedBYSM = approval.RecommandedBYSM;
                    }
                }
                return db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
