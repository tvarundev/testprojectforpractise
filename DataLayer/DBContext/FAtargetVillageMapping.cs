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
    
    public partial class FAtargetVillageMapping
    {
        public int Id { get; set; }
        public Nullable<int> TargetId { get; set; }
        public Nullable<int> CropId { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public Nullable<int> TotalMonths { get; set; }
        public Nullable<int> NoOfSamples { get; set; }
        public Nullable<int> NoOfDemos { get; set; }
        public Nullable<int> NoOfFarmerMeetings { get; set; }
        public Nullable<int> NoOfPrescriptions { get; set; }
    
        public virtual CropInfo CropInfo { get; set; }
        public virtual FAtargetDetail FAtargetDetail { get; set; }
    }
}