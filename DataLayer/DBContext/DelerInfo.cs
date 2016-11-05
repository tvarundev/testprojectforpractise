//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer.DBContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class DelerInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DelerInfo()
        {
            this.DelerAddInfoes = new HashSet<DelerAddInfo>();
            this.DelerBankInfoes = new HashSet<DelerBankInfo>();
            this.DelerLicencesInfoes = new HashSet<DelerLicencesInfo>();
            this.DelerPartenarInfoes = new HashSet<DelerPartenarInfo>();
            this.FarmerDealerMappings = new HashSet<FarmerDealerMapping>();
            this.FarmerInputSourceMappings = new HashSet<FarmerInputSourceMapping>();
        }
    
        public int DelerID { get; set; }
        public int ExistingCodeNo { get; set; }
        public int FormNo { get; set; }
        public int PreparedBy { get; set; }
        public int ApprovedBy { get; set; }
        public string CodeNo { get; set; }
        public string EstablishmentName { get; set; }
        public int DelerTypeID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DelerAddInfo> DelerAddInfoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DelerBankInfo> DelerBankInfoes { get; set; }
        public virtual DelerType DelerType { get; set; }
        public virtual UserInformation UserInformation { get; set; }
        public virtual UserInformation UserInformation1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DelerLicencesInfo> DelerLicencesInfoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DelerPartenarInfo> DelerPartenarInfoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FarmerDealerMapping> FarmerDealerMappings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FarmerInputSourceMapping> FarmerInputSourceMappings { get; set; }
    }
}
