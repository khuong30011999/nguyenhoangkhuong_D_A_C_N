//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DABongDa.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BANGTONGKET
    {
        public string DoiBong { get; set; }
        public Nullable<int> SoTran { get; set; }
        public Nullable<int> T { get; set; }
        public Nullable<int> B { get; set; }
        public Nullable<int> H { get; set; }
        public Nullable<int> HS { get; set; }
        public Nullable<int> TV { get; set; }
        public Nullable<int> TD { get; set; }
        public Nullable<int> Diem { get; set; }
    
        public virtual DOIBONG DOIBONG1 { get; set; }
    }
}
