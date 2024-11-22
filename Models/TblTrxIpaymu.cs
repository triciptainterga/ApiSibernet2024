using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.Models
{
    public partial class TblTrxIpaymu
    {
        public int Id { get; set; }
        public int TrxId { get; set; }
        public string Invoice { get; set; }
        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string PlanName { get; set; }
        public string SessionId { get; set; }
        public DateTime TransactionTime { get; set; }
        public string TransactionStatus { get; set; }
        public string StatusCode { get; set; }
        public string PaymentType { get; set; }
        public string PaymentChannel { get; set; }
        public string PaymentCode { get; set; }
        public string Amount { get; set; }
        public string Fee { get; set; }
        public string Total { get; set; }
        public DateTime? ExpiredOn { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}
