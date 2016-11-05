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
    
    public partial class FAexperianceDetail
    {
        public int Id { get; set; }
        public Nullable<int> FAid { get; set; }
        public string OrganitionName { get; set; }
        public Nullable<int> FromMonth { get; set; }
        public Nullable<int> FromYear { get; set; }
        public Nullable<int> ToMonth { get; set; }
        public Nullable<int> ToYear { get; set; }
        public string Designation { get; set; }
        public Nullable<int> PaymentAgencyId { get; set; }
        public Nullable<int> SalaryPerMonth { get; set; }
        public Nullable<int> SalaryPerDay { get; set; }
        public Nullable<int> DA { get; set; }
        public Nullable<int> TA { get; set; }
        public Nullable<int> Travel { get; set; }
        public Nullable<int> MobileAllowance { get; set; }
        public Nullable<bool> IsExperience { get; set; }
        public string RecomandDealerInfo { get; set; }
        public string WorkArea { get; set; }
    
        public virtual FAdetail FAdetail { get; set; }
        public virtual FApaymentAgency FApaymentAgency { get; set; }
    }
}
