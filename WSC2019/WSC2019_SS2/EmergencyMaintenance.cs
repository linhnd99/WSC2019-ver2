//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSC2019_SS2
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmergencyMaintenance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmergencyMaintenance()
        {
            this.ChangedParts = new HashSet<ChangedPart>();
        }
    
        public int ID { get; set; }
        public Nullable<int> AssetID { get; set; }
        public Nullable<int> PriorityID { get; set; }
        public string DescriptionEmergency { get; set; }
        public string OtherConsiderations { get; set; }
        public Nullable<System.DateTime> EMReportDate { get; set; }
        public Nullable<System.DateTime> EMStartDate { get; set; }
        public Nullable<System.DateTime> EMEndDate { get; set; }
        public string EMTechinicianNote { get; set; }
    
        public virtual Asset Asset { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChangedPart> ChangedParts { get; set; }
        public virtual Priority Priority { get; set; }
    }
}