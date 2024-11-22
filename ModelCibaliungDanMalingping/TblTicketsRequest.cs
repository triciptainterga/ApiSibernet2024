using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.ModelCibaliungDanMalingping
{
    public partial class TblTicketsRequest
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TicketNumber { get; set; }
        public string Department { get; set; }
        public string Subject { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public int CustomerId { get; set; }
        public string MemberId { get; set; }
        public string Email { get; set; }
        public DateTime LastUpdate { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}
