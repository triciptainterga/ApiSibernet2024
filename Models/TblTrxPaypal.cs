using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.Models
{
    public partial class TblTrxPaypal
    {
        public int Id { get; set; }
        public string TrxId { get; set; }
        public string Invoice { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PlanName { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionStatus { get; set; }
        public string Amount { get; set; }
        public string Fee { get; set; }
        public string Total { get; set; }
        public string Currency { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}
