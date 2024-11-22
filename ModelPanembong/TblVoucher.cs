using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.ModelPanembong
{
    public partial class TblVoucher
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Secret { get; set; }
        public string Type { get; set; }
        public string Servicetype { get; set; }
        public string Nasporttype { get; set; }
        public string ServerName { get; set; }
        public string Method { get; set; }
        public string PlanName { get; set; }
        public string Price { get; set; }
        public string SellerFee { get; set; }
        public string Tax { get; set; }
        public string Total { get; set; }
        public string Validity { get; set; }
        public string Bandwidth { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ExpiredOn { get; set; }
        public string Status { get; set; }
        public string TrxInvoice { get; set; }
        public string TrxStatus { get; set; }
        public string AuthStatus { get; set; }
        public string BindMac { get; set; }
        public string MacAddress { get; set; }
        public string EvcFullname { get; set; }
        public string EvcEmail { get; set; }
        public string EvcWanumber { get; set; }
        public int EvcStatus { get; set; }
        public string EvcPayment { get; set; }
        public string EvcChannel { get; set; }
        public string EvcOrderId { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}
