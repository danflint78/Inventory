using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InventorySite.Models
{
    public class ComputerMetadata
    {
        [StringLength(50)]
        [Display(Name = "Computer Name")]
        public string Name;
        
        [StringLength(50)]
        [Display(Name = "Form Factor")]
        public string FormFactor;

        [StringLength(50)]
        [Display(Name = "Primary MAC Address")]
        public string PrimaryMac;

        [Display(Name = "Purchase Date")]
        public Nullable<System.DateTime> PurchaseDate;

        [Display(Name = "Install Date")]
        public Nullable<System.DateTime> InstallDate;
    }

    public class HarddriveMetadata
    {
        [StringLength(25)]
        public string Type;

        [Range(20, 10240)]
        public int Capacity;
    }

    public class MotherboardMetadata
    {
        [StringLength(50)]
        public string Make;

        [StringLength(50)]
        public string Model;

        [Range(1, 10)]
        [Display(Name = "Number of Display Ports")]
        public int NumberOfDisplayPorts;

        [Range(1, 16)]
        [Display(Name = "Number of Memory Slots")]
        public int NumberOfMemoryPorts;

        [Display(Name = "Has a Parallel Port")]
        public bool HasParallelPort;
    }

    public class OperatingSystemMetadata
    {
        [StringLength(50)]
        public string Name;

        [StringLength(50)]
        public string Version;
    }

    public class ProcessorMetadata
    {
        [StringLength(50)]
        public string Make;

        [StringLength(50)]
        public string Model;

        [Range(1, 36)]
        [Display(Name = "Number of Cores")]
        public int NumberOfCores;

        [Range(1, 6)]
        public decimal Speed;
    }

    public class RAMMetadata
    {
        [StringLength(50)]
        public string Type;

        [Range(800, 50000)]
        public int Speed;

        [Range(1, 1024)]
        public int Amount;
    }
}