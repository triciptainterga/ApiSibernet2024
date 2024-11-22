using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.ModelCibaliungDanMalingping
{
    public partial class TblTrxMidtran
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public int CustomerId { get; set; }
        public string MemberId { get; set; }
        public string Username { get; set; }
        public string PlanName { get; set; }
        public string TransactionId { get; set; }
        public DateTime TransactionTime { get; set; }
        public string TransactionStatus { get; set; }
        public DateTime? SettlementTime { get; set; }
        public string StatusCode { get; set; }
        public string SignatureKey { get; set; }
        public string PaymentType { get; set; }
        public string PaymentChannel { get; set; }
        public string PaymentCode { get; set; }
        public string Amount { get; set; }
        public string Fee { get; set; }
        public string GrossAmount { get; set; }
        public DateTime? PaidAt { get; set; }
        public string FraudStatus { get; set; }
        public string Currency { get; set; }
        public string MerchantId { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}
