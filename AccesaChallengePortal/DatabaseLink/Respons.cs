//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccesaChallengePortal.DatabaseLink
{
    using System;
    using System.Collections.Generic;
    
    public partial class Respons
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public System.DateTime ReviewDate { get; set; }
        public int UserId { get; set; }
        public int ChallengeId { get; set; }
        public Nullable<int> Grade { get; set; }
        public string Notes { get; set; }
        public string Reviewer { get; set; }
    
        public virtual Challenge Challenge { get; set; }
        public virtual User User { get; set; }
    }
}
