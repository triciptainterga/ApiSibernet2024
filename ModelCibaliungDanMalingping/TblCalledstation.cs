using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.ModelCibaliungDanMalingping
{
    public partial class TblCalledstation
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Nas { get; set; }
        public string Calledstation { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}
