using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.ModelCibaliungDanMalingping
{
    public partial class TblTrxXendit
    {
        public int Id { get; set; }
        public string TrxId { get; set; }
        public string Invoice { get; set; }
        public string ExternalId { get; set; }
        public string MemberId { get; set; }
        public string Username { get; set; }
        public string PlanName { get; set; }
        public string TransactionStatus { get; set; }
        public string PaymentChannel { get; set; }
        public string PaymentCode { get; set; }
        public DateTime? ExpiredOn { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Amount { get; set; }
        public string Fee { get; set; }
        public string Total { get; set; }
        public string PaidAmount { get; set; }
        public DateTime? PaidAt { get; set; }
        public string Currency { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}
