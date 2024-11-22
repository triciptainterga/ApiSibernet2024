using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.Models
{
    public partial class TblTicketsContent
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Message { get; set; }
        public string RepliedBy { get; set; }
        public DateTime ReplyDate { get; set; }
        public int? ReplyStatus { get; set; }
    }
}
