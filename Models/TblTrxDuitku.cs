using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.Models
{
    public partial class TblTrxDuitku
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public string PaymentUrl { get; set; }
        public string Invoice { get; set; }
        public string OrderKey { get; set; }
        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string PlanName { get; set; }
        public DateTime TransactionTime { get; set; }
        public string TransactionStatus { get; set; }
        public string StatusCode { get; set; }
        public string PaymentChannel { get; set; }
        public string PaymentCode { get; set; }
        public string MerchantCode { get; set; }
        public string Amount { get; set; }
        public DateTime? ExpiredOn { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}
