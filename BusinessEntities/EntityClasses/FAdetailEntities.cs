using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BusinessEntities.EntityClasses
{
    public class FAdetailEntities
    {
        public int Id { get; set; }
        public string FormNo { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Required")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EnrollDate { get; set; }
        [Required(ErrorMessage = "Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Required")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Required")]
        public string FAname { get; set; }
        [Required(ErrorMessage = "Required")]
        public string GetName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public System.DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Required")]
        public int FAdesignationId { get; set; }
        [Required(ErrorMessage = "Required")]
        public bool IsExperienced { get; set; }
        [Required(ErrorMessage = "Required")]
        public Nullable<int> Status { get; set; }

        public string StatusName { get; set; }
        public FAaddressDetailEntities AddressDetailEntities { get; set; }
        public FAapprovalEntities ApprovalEntities { get; set; }
        public List<FAeducationDetailEntities> EducationDetailEntityList { get; set; }
        public List<FAexperianceDetailEntities> ExperienceDetailEntityList { get; set; }
        public List<FAtargetDetailEntities> TargetDetailEntityList { get; set; }
        public List<FAuploadedDocumentDetailEntities> UploadedDocumentList { get; set; }
        public PocketInfoEntities pocketDetail { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }

    }
}
