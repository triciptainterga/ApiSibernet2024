using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.ModelCibaliungDanMalingping
{
    public partial class TblProfileGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string PoolModule { get; set; }
        public string LocalAddress { get; set; }
        public string FirstAddress { get; set; }
        public string LastAddress { get; set; }
        public string Nasshortname { get; set; }
        public string DnsServers { get; set; }
        public string ParentName { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}
