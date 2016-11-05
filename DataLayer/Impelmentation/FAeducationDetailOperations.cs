using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using DataLayer.DBContext;
namespace DataLayer.Impelmentation
{
    public class FAeducationDetailOperations : IFAeducationDetailOperations
    {
        DBentities db = new DBentities();
        public IEnumerable<FAeducationDetail> InsertFAeducationDetail(IEnumerable<FAeducationDetail> faEducationDetailList)
        {
            try
            {
                foreach (var educationDetail in faEducationDetailList)
                {
                    db.FAeducationDetails.Add(educationDetail);
                }
                db.SaveChanges();
                return faEducationDetailList;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public int RemoveEducationDetailForFA(int FAid)
        {
            try
            {
                List<FAeducationDetail> faEducationDetailList = db.FAeducationDetails.Select(x => x).Where(x => x.FAid == FAid).ToList();
                if (faEducationDetailList.Count() > 0)
                {
                    foreach (var educationDetail in faEducationDetailList)
                    {
                        db.FAeducationDetails.Remove(educationDetail);
                    }
                }
                return db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public int UpdateEducationDetailForFA(List<FAeducationDetail> EducationDetailList)
        {
            try
            {
                int faId = EducationDetailList.ElementAt(0).FAid.Value;
                List<FAeducationDetail> ExistingEducationList = db.FAeducationDetails.Select(x => x).Where(x => x.FAid.Value == faId).ToList();

                List<FAeducationDetail> EducationListToAdd = new List<FAeducationDetail>();
                List<FAeducationDetail> EducationListToUpdate = new List<FAeducationDetail>();
                List<FAeducationDetail> EducationListToDelete = new List<FAeducationDetail>();

                foreach (var experience in EducationDetailList)
                {
                    FAeducationDetail newEducation = ExistingEducationList.Select(x => x).Where(x => x.Id == experience.Id).FirstOrDefault();
                    if (newEducation == null)
                    {
                        EducationListToAdd.Add(experience);
                    }
                    else
                    {
                        EducationListToUpdate.Add(experience);
                    }
                }
                foreach (var education in ExistingEducationList)
                {
                    FAeducationDetail existingEducation = EducationDetailList.Select(x => x).Where(x => x.Id == education.Id).FirstOrDefault();
                    if (existingEducation == null)
                    {
                        EducationListToDelete.Add(education);
                    }
                }

                InsertFAeducationDetail(EducationListToAdd);

                foreach (var education in EducationListToDelete)
                {
                    //RemoveEducationDetailForFA(education.Id);
                    FAeducationDetail eduDetail = db.FAeducationDetails.Select(x => x).Where(x => x.Id == education.Id).FirstOrDefault();
                    db.FAeducationDetails.Remove(eduDetail);
                }
                FAeducationDetail educationToUpdate;
                foreach (var education in EducationListToUpdate)
                {
                    educationToUpdate = ExistingEducationList.Select(x => x).Where(x => x.Id == education.Id).FirstOrDefault();
                    if (educationToUpdate != null)
                    {
                        educationToUpdate.Examination = education.Examination;
                        educationToUpdate.Grade = education.Grade;
                        educationToUpdate.Percentage = education.Percentage;
                        educationToUpdate.Subjects = education.Subjects;
                        educationToUpdate.University = education.University;
                        educationToUpdate.Year = education.Year;
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
