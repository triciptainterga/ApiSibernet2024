using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.ModelCibaliungDanMalingping
{
    public partial class TblVouchersTpl
    {
        public int Id { get; set; }
        public string TemplateName { get; set; }
        public string FileName { get; set; }
        public string Status { get; set; }
        public int OwnerId { get; set; }
    }
}
