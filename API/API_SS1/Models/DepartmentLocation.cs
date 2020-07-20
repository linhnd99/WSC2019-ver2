//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API_SS1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DepartmentLocation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DepartmentLocation()
        {
            this.Assets = new HashSet<Asset>();
            this.AssetTransferLogs = new HashSet<AssetTransferLog>();
            this.AssetTransferLogs1 = new HashSet<AssetTransferLog>();
        }
    
        public int ID { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public Nullable<int> LocationID { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asset> Assets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssetTransferLog> AssetTransferLogs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssetTransferLog> AssetTransferLogs1 { get; set; }
        public virtual Department Department { get; set; }
        public virtual Location Location { get; set; }
    }
}