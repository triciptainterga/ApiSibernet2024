using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.Models
{
    public partial class TblBandwidth
    {
        public int Id { get; set; }
        public string NameBw { get; set; }
        public string MinRateUp { get; set; }
        public string MinRateUpUnit { get; set; }
        public string MaxRateUp { get; set; }
        public string MaxRateUpUnit { get; set; }
        public string MinRateDown { get; set; }
        public string MinRateDownUnit { get; set; }
        public string MaxRateDown { get; set; }
        public string MaxRateDownUnit { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}
