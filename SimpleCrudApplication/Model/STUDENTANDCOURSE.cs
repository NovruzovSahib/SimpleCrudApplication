//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SimpleCrudApplication.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class STUDENTANDCOURSE
    {
        public int ID { get; set; }
        public Nullable<int> STUDENTID { get; set; }
        public Nullable<int> COURSEID { get; set; }
    
        public virtual COURSE COURSE { get; set; }
        public virtual STUDENT STUDENT { get; set; }
    }
}
