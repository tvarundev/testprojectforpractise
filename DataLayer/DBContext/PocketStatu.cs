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
    
    public partial class PocketStatu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PocketStatu()
        {
            this.PocketInfoes = new HashSet<PocketInfo>();
        }
    
        public int Id { get; set; }
        public string PocketStatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PocketInfo> PocketInfoes { get; set; }
    }
}