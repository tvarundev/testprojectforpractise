using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
using DataLayer.Interfaces;
namespace DataLayer.Impelmentation
{
    public class FAdetailOperations:IFAdetailOperations
    {
        DBentities db = new DBentities();
        public int InsertFAdetail(FAdetail faDetail)
        {
            try
            {
                faDetail.FormNo =(faDetail.FirstName.Length>3? faDetail.FirstName.Substring(0, 3):faDetail.FirstName.Substring(0,faDetail.FirstName.Length))+ faDetail.EnrollDate.Value.Day + faDetail.EnrollDate.Value.Month + faDetail.EnrollDate.Value.Year;
                db.FAdetails.Add(faDetail);
                db.SaveChanges();
                return faDetail.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<FAdetail> GetFAdetailList()
        {
            try
            {
                return db.FAdetails.Select(x => x).ToList();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }


        public FAdetail GetFAdetailById(int id)
        {
            try
            {
                return db.FAdetails.Select(x => x).Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public int RemoveFAdetail(int FAid)
        {
            try
            {
                IFAtargetOperations targetOperation = new FAtargetOperations();
                IFAeducationDetailOperations educationOperation = new FAeducationDetailOperations();
                IFAexperianceDetailOperations experienceOperation = new FAexperianceDetailOperations();
                IFAapprovalOperations approvalOperation = new FAapprovalOperations();
                IFAaddressDetailOperations addressOperation = new FAaddressDetailOperations();

                FAdetail faDetail = db.FAdetails.Select(x => x).Where(x => x.Id == FAid).FirstOrDefault();
                if(faDetail!= null)
                {
                    int Faid = faDetail.Id;
                    //targetOperation.RemoveTargetsForFA(Faid);
                    //educationOperation.RemoveEducationDetailForFA(Faid);
                    //experienceOperation.RemoveExperienceDetailForFA(Faid);
                    //approvalOperation.RemoveApprovalDetailForFA(Faid);
                    //addressOperation.RemoveFAaddressDetail(Faid);
                    //db.FAdetails.Remove(faDetail);
                    faDetail.Status = 3;
                }
                return db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public int UpdateFAdetail(FAdetail faDetail)
        {
            try
            {
                IFAtargetOperations targetOperation = new FAtargetOperations();
                IFAeducationDetailOperations educationOperation = new FAeducationDetailOperations();
                IFAexperianceDetailOperations experienceOperation = new FAexperianceDetailOperations();
                IFAapprovalOperations approvalOperation = new FAapprovalOperations();
                IFAaddressDetailOperations addressOperation = new FAaddressDetailOperations();

                FAdetail faDetailToUpdate = db.FAdetails.Select(x => x).Where(x => x.Id == faDetail.Id).FirstOrDefault();

                if (faDetailToUpdate != null)
                {
                    faDetailToUpdate.BirthDate = faDetail.BirthDate;
                    faDetailToUpdate.FAdesignationId = faDetail.FAdesignationId;
                    faDetailToUpdate.FAname = faDetail.FAname;
                    faDetailToUpdate.FAStatu = faDetail.FAStatu;
                    faDetailToUpdate.FirstName = faDetail.FirstName;
                    faDetailToUpdate.IsExperienced = faDetail.IsExperienced;
                    faDetailToUpdate.LastName = faDetail.LastName;
                    faDetailToUpdate.MiddleName = faDetail.MiddleName;
                    faDetailToUpdate.Status = faDetail.Status;
                    faDetailToUpdate.UpdatedBy = faDetail.UpdatedBy;
                    faDetailToUpdate.LastUpdated = faDetail.LastUpdated;
                }

                targetOperation.UpdateTargetForFA(faDetail.FAtargetDetails.ToList());
                educationOperation.UpdateEducationDetailForFA(faDetail.FAeducationDetails.ToList());
                experienceOperation.UpdateExperienceDetailForFA(faDetail.FAexperianceDetails.ToList());
                approvalOperation.UpdateApprovalForFA(faDetail.FAapprovals.ToList());
                addressOperation.UpdateFAaddressDetail(faDetail.FAaddressDetails.ToList());


                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}
