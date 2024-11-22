using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.ModelCibaliungDanMalingping
{
    public partial class TblOdpDatum
    {
        public int Id { get; set; }
        public string OdpName { get; set; }
        public string OdpArea { get; set; }
        public string OdpLatitude { get; set; }
        public string OdpLongitude { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}
