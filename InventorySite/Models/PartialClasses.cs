using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InventorySite.Models
{
    [MetadataType(typeof(ComputerMetadata))]
    public partial class Computer
    {
    }

    [MetadataType(typeof(HarddriveMetadata))]
    public partial class Harddrive
    {
    }

    [MetadataType(typeof(MotherboardMetadata))]
    public partial class Motherboard
    {
    }

    [MetadataType(typeof(OperatingSystemMetadata))]
    public partial class OperatingSystem
    {
    }

    [MetadataType(typeof(ProcessorMetadata))]
    public partial class Processor
    {
    }

    [MetadataType(typeof(RAMMetadata))]
    public partial class RAM
    {
    }
}