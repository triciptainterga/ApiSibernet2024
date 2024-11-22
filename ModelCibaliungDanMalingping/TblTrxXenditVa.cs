using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.ModelCibaliungDanMalingping
{
    public partial class TblTrxXenditVa
    {
        public int Id { get; set; }
        public string FvaId { get; set; }
        public string ExternalId { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; }
        public string PaymentChannel { get; set; }
        public string PaymentCode { get; set; }
        public string ExpectedAmount { get; set; }
        public string MerchantCode { get; set; }
        public string Name { get; set; }
        public string SignatureKey { get; set; }
        public DateTime ExpiredOn { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}
