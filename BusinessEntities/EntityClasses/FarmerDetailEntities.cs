using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BusinessEntities.EntityClasses
{
    public class FarmerDetailEntities
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> RegistrationDate { get; set; }
        [Required(ErrorMessage = "Required")]
        public string DealerId { get; set; }
         [Required(ErrorMessage = "Required")]
        public int FarmerTypeId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string FarmerFirstName { get; set; }
         [Required(ErrorMessage = "Required")]
        public string FarmerMiddleName { get; set; }
         [Required(ErrorMessage = "Required")]
        public string FarmerLastName { get; set; }
         public string GetName
         {
             get
             {
                 return FarmerFirstName + " " + FarmerLastName;
             }
         }
        [Required(ErrorMessage = "Required")]
        public int PocketId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string FarmerAddress { get; set; }
        [Required(ErrorMessage = "Required")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Required")]
        public string FertiCons { get; set; }
        [Required(ErrorMessage = "Required")]
        public string DAP { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Urea { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Potash { get; set; }
        [Required(ErrorMessage = "Required")]
        public Nullable<decimal> LandTotal { get; set; }
        [Required(ErrorMessage = "Required")]
        public Nullable<decimal> IrrigatedFields { get; set; }
        [Required(ErrorMessage = "Required")]
        public int SourceId { get; set; }
        public Nullable<decimal> DryLandFields { get; set; }
        [Required(ErrorMessage = "Required")]
        public string FarmerDealerPesticides { get; set; }
        [Required(ErrorMessage = "Required")]
        public string FarmerDealerFertilizer { get; set; }
        [Required(ErrorMessage = "Required")]
        public string FarmerDealerSeeds { get; set; }
        [Required(ErrorMessage = "Required")]
        public string SampleDemoDetails { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> CreatedDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> LastUpdate { get; set; }

        //public List<FarmerCropMappingEntities> lastYearCropObjectList { get; set; }
        //public List<FarmerCropMappingEntities> currentYearCropObjectList { get; set; }
        //public List<FarmerPesticesMappingEntities> pesticeObjectList { get; set; }

        public List<FarmerConsumptionMappingEntities> farmerConsumptionMappingList = new List<FarmerConsumptionMappingEntities>();

        public List<FarmerPesticesMappingEntities> farmerPestiesMappingList = new List<FarmerPesticesMappingEntities>();
        public List<FarmerLandMappingEntities> farmerLandMappingList = new List<FarmerLandMappingEntities>();
        public List<FarmerCropMappingEntities> farmerCropMappingList = new List<FarmerCropMappingEntities>();
        public List<FarmerInputSourceMappingEntities> inputSoruceList = new List<FarmerInputSourceMappingEntities>();
    }
}
