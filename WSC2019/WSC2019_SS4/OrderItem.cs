//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSC2019_SS4
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderItem
    {
        public int ID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public Nullable<int> PartID { get; set; }
        public string BatchNumber { get; set; }
        public Nullable<double> Amount { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Part Part { get; set; }
    }
}
