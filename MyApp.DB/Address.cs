//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyApp.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Address
    {
        public Address()
        {
            this.Employee = new HashSet<Employee>();
        }
    
        public int id { get; set; }
        public string Details { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    
        public virtual Address Address1 { get; set; }
        public virtual Address Address2 { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
