using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.ModelPanembong
{
    public partial class TblVouchersEvc
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public string PgTrxId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Wanumber { get; set; }
        public string PlanName { get; set; }
        public string BwName { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }
        public string Type { get; set; }
        public string HsDomain { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public string PaidDate { get; set; }
        public string StatusCode { get; set; }
        public string PaymentChannel { get; set; }
        public string MerchantName { get; set; }
        public string PaymentUrl { get; set; }
    }
}
