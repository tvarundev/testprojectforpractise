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
    
    public partial class PocketFertilizerMapping
    {
        public int Id { get; set; }
        public Nullable<int> PocketId { get; set; }
        public Nullable<int> FertilizerId { get; set; }
    
        public virtual FertilizerInfo FertilizerInfo { get; set; }
        public virtual PocketInfo PocketInfo { get; set; }
    }
}