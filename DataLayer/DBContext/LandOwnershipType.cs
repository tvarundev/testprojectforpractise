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
    
    public partial class LandOwnershipType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LandOwnershipType()
        {
            this.FarmerLandMappings = new HashSet<FarmerLandMapping>();
        }
    
        public int Id { get; set; }
        public string OwnershipType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FarmerLandMapping> FarmerLandMappings { get; set; }
    }
}
