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
    
    public partial class FarmerTypeDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FarmerTypeDetail()
        {
            this.FarmerDetails = new HashSet<FarmerDetail>();
        }
    
        public int id { get; set; }
        public string farmerType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FarmerDetail> FarmerDetails { get; set; }
    }
}
