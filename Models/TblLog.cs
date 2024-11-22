using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.Models
{
    public partial class TblLog
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Nas { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Userid { get; set; }
        public string Ip { get; set; }
    }
}
