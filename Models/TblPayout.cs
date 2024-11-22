using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.Models
{
    public partial class TblPayout
    {
        public int Id { get; set; }
        public DateTime PayoutDate { get; set; }
        public string PayoutType { get; set; }
        public string PayoutDescription { get; set; }
        public string PayoutAmount { get; set; }
        public string PaidBy { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}
