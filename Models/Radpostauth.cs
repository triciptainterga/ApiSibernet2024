using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.Models
{
    public partial class Radpostauth
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Nas { get; set; }
        public string Calledstationid { get; set; }
        public string Callingstationid { get; set; }
        public string Reply { get; set; }
    }
}
