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
    
    public partial class FAaddressDetail
    {
        public int Id { get; set; }
        public Nullable<int> FAdetailId { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> District { get; set; }
        public Nullable<int> PocketId { get; set; }
        public Nullable<int> SubDistrictId { get; set; }
        public Nullable<int> Village { get; set; }
        public string ContactNo { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
    
        public virtual DistrictInfo DistrictInfo { get; set; }
        public virtual FAdetail FAdetail { get; set; }
        public virtual PocketInfo PocketInfo { get; set; }
        public virtual StateInfo StateInfo { get; set; }
        public virtual SubDistrictInfo SubDistrictInfo { get; set; }
        public virtual VillageInfo VillageInfo { get; set; }
    }
}