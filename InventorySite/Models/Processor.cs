//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventorySite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Processor
    {
        public int ProcessorID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public Nullable<int> NumberOfCores { get; set; }
        public Nullable<decimal> Speed { get; set; }
        public int ComputerID { get; set; }
    
        public virtual Computer Computer { get; set; }
    }
}
