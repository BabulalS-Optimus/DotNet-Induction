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
    
    public partial class User
    {
        public User()
        {
            this.Activities = new HashSet<Activity>();
            this.Activities1 = new HashSet<Activity>();
            this.Answers = new HashSet<Answer>();
            this.Tests = new HashSet<Test>();
        }
    
        public decimal ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string Role { get; set; }
    
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Activity> Activities1 { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }
}
