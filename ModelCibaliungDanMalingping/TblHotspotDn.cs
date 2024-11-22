using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.ModelCibaliungDanMalingping
{
    public partial class TblHotspotDn
    {
        public int Id { get; set; }
        public string HotspotDomain { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public int EvoucherVisibility { get; set; }
    }
}
