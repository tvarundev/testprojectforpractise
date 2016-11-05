using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using DataLayer.DBContext;
namespace DataLayer.Impelmentation
{
    public class FAexperianceDetailOperations : IFAexperianceDetailOperations
    {
        DBentities db = new DBentities();
        public IEnumerable<FAexperianceDetail> InsertFAexperienceDetail(IEnumerable<FAexperianceDetail> faExperienceDetailList)
        {
            try
            {

                foreach (var expDetail in faExperienceDetailList)
                {
                    db.FAexperianceDetails.Add(expDetail);
                }
                db.SaveChanges();
                return faExperienceDetailList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public int RemoveExperienceDetailForFA(int FAid)
        {
            try
            {
                List<FAexperianceDetail> faExperienceDetailList = db.FAexperianceDetails.Select(x => x).Where(x => x.FAid == FAid).ToList();
                if (faExperienceDetailList.Count > 0)
                {
                    foreach (var expDetail in faExperienceDetailList)
                    {
                        db.FAexperianceDetails.Remove(expDetail);
                    }

                }
                return db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public int UpdateExperienceDetailForFA(List<FAexperianceDetail> faExperienceDetail)
        {
            try
            {
                int faId = faExperienceDetail.ElementAt(0).FAid.Value;
                List<FAexperianceDetail> ExistingExeprienceList = db.FAexperianceDetails.Select(x => x).Where(x => x.FAid.Value == faId).ToList();

                List<FAexperianceDetail> ExperienceListToAdd = new List<FAexperianceDetail>();
                List<FAexperianceDetail> ExperienceListToUpdate = new List<FAexperianceDetail>();
                List<FAexperianceDetail> ExperienceListToDelete = new List<FAexperianceDetail>();

                foreach (var experience in faExperienceDetail)
                {
                    FAexperianceDetail newExperience = ExistingExeprienceList.Select(x => x).Where(x => x.Id == experience.Id).FirstOrDefault();
                    if (newExperience == null)
                    {
                        ExperienceListToAdd.Add(experience);
                    }
                    else
                    {
                        ExperienceListToUpdate.Add(experience);
                    }
                }
                foreach (var experience in ExistingExeprienceList)
                {
                    FAexperianceDetail existingExperiance = faExperienceDetail.Select(x => x).Where(x => x.Id == experience.Id).FirstOrDefault();
                    if (existingExperiance == null)
                    {
                        ExperienceListToDelete.Add(experience);
                    }
                }

                InsertFAexperienceDetail(ExperienceListToAdd);

                foreach (var experience in ExperienceListToDelete)
                {
                    //RemoveExperienceDetailForFA(experience.Id);

                    FAexperianceDetail expDtl = db.FAexperianceDetails.Select(x => x).Where(x => x.Id == experience.Id).FirstOrDefault();
                    if(expDtl!=null)
                    {
                        db.FAexperianceDetails.Remove(expDtl);
                    }
                }
                FAexperianceDetail experienceToUpdate;
                foreach (var experience in ExperienceListToUpdate)
                {
                    experienceToUpdate = ExistingExeprienceList.Select(x => x).Where(x => x.Id == experience.Id).FirstOrDefault();
                    if (experienceToUpdate != null)
                    {
                        experienceToUpdate.DA = experience.DA;
                        experienceToUpdate.Designation = experience.Designation;
                        experienceToUpdate.FromMonth = experience.FromMonth;
                        experienceToUpdate.FromYear = experience.FromYear;
                        experienceToUpdate.IsExperience = experience.IsExperience;
                        experienceToUpdate.MobileAllowance = experience.MobileAllowance;
                        experienceToUpdate.OrganitionName = experience.OrganitionName;
                        experienceToUpdate.PaymentAgencyId = experience.PaymentAgencyId;
                        experienceToUpdate.RecomandDealerInfo = experience.RecomandDealerInfo;
                        experienceToUpdate.SalaryPerDay = experience.SalaryPerDay;
                        experienceToUpdate.SalaryPerMonth = experience.SalaryPerMonth;
                        experienceToUpdate.TA = experience.TA;
                        experienceToUpdate.ToMonth = experience.ToMonth;
                        experienceToUpdate.ToYear = experience.ToYear;
                        experienceToUpdate.Travel = experience.Travel;
                        experienceToUpdate.WorkArea = experience.WorkArea;
                       
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
