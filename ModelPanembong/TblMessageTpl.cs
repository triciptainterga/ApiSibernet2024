using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.ModelPanembong
{
    public partial class TblMessageTpl
    {
        public int Id { get; set; }
        public string Channel { get; set; }
        public string Vendor { get; set; }
        public string RegistrationMsg { get; set; }
        public string DueinfoMsg { get; set; }
        public string RenewalMsg { get; set; }
    }
}
