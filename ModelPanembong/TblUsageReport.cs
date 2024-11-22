using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.ModelPanembong
{
    public partial class TblUsageReport
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public DateTime? RenewedOn { get; set; }
        public DateTime? ExpiredOn { get; set; }
        public string Method { get; set; }
        public string Type { get; set; }
        public long? OnlineTime { get; set; }
        public long? QuotaUsed { get; set; }
        public string LastDevice { get; set; }
        public string LastSessionId { get; set; }
        public string LastUniqueId { get; set; }
    }
}
