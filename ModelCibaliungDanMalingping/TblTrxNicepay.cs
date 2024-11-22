using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.ModelCibaliungDanMalingping
{
    public partial class TblTrxNicepay
    {
        public int Id { get; set; }
        public string TrxId { get; set; }
        public string Reference { get; set; }
        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string PlanName { get; set; }
        public DateTime TransactionDate { get; set; }
        public TimeSpan TransactionTime { get; set; }
        public string TransactionStatus { get; set; }
        public string StatusCode { get; set; }
        public string PaymentType { get; set; }
        public string PaymentChannel { get; set; }
        public string PaymentCode { get; set; }
        public string Amount { get; set; }
        public string Fee { get; set; }
        public string Total { get; set; }
        public string Currency { get; set; }
        public DateTime? ExpiredOn { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}
