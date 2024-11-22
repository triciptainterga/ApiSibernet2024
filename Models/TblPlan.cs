using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.Models
{
    public partial class TblPlan
    {
        public int Id { get; set; }
        public string NamePlan { get; set; }
        public string BwName { get; set; }
        public string BurstBw { get; set; }
        public string Price { get; set; }
        public string SellPrice { get; set; }
        public string Tax { get; set; }
        public string Type { get; set; }
        public string Typebp { get; set; }
        public string LimitType { get; set; }
        public int? TimeLimit { get; set; }
        public string TimeUnit { get; set; }
        public int? DataLimit { get; set; }
        public string DataUnit { get; set; }
        public int Validity { get; set; }
        public string ValidityUnit { get; set; }
        public string Priority { get; set; }
        public int? SharedUsers { get; set; }
        public string ProfileGroup { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public int? PlanVisibility { get; set; }
        public int EvoucherVisibility { get; set; }
    }
}
