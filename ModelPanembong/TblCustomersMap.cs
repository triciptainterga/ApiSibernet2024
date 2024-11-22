using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.ModelPanembong
{
    public partial class TblCustomersMap
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int OdpId { get; set; }
    }
}
