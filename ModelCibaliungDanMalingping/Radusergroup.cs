using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.ModelCibaliungDanMalingping
{
    public partial class Radusergroup
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Groupname { get; set; }
        public int Priority { get; set; }
        public string Type { get; set; }
        public string Method { get; set; }
    }
}
