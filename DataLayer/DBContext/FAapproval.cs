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
    
    public partial class FAapproval
    {
        public int Id { get; set; }
        public Nullable<int> FAid { get; set; }
        public Nullable<int> FAApprovedId { get; set; }
        public Nullable<int> PocketId { get; set; }
        public string RecommandedBYSM { get; set; }
    
        public virtual FAapprovedBy FAapprovedBy { get; set; }
        public virtual FAdetail FAdetail { get; set; }
    }
}