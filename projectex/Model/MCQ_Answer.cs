//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace projectex
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class MCQ_Answer
    {
        [Key]
        public int MCQ_Id { get; set; }
        public string Answer { get; set; }
        public Nullable<int> Student_Answer_Id { get; set; }
        public Nullable<int> answer_degree { get; set; }
    
        public virtual Student_Answer Student_Answer { get; set; }
    }
}
