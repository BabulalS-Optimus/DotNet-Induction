//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineExaminationSystem.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Test
    {
        public Test()
        {
            this.Activities = new HashSet<Activity>();
            this.Answers = new HashSet<Answer>();
            this.Questions = new HashSet<Question>();
        }
    
        public decimal ID { get; set; }
        public string Title { get; set; }
        public Nullable<decimal> Organiser { get; set; }
    
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual User User { get; set; }
    }
}
