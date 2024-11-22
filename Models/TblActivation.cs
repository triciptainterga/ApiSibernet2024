using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.Models
{
    public partial class TblActivation
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string RequestId { get; set; }
        public string HardwareId { get; set; }
        public string SoftwareKey { get; set; }
        public DateTime ActivationDate { get; set; }
    }
}
