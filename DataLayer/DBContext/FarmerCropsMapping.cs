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
    
    public partial class FarmerCropsMapping
    {
        public int id { get; set; }
        public Nullable<int> farmerId { get; set; }
        public Nullable<int> cropId { get; set; }
        public Nullable<decimal> acre { get; set; }
        public Nullable<int> cropYear { get; set; }
        public Nullable<bool> isActive { get; set; }
    
        public virtual CropInfo CropInfo { get; set; }
        public virtual FarmerDetail FarmerDetail { get; set; }
    }
}
