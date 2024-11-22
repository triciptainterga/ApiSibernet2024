using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.Models
{
    public partial class TblTransactionResponse
    {
        public int Id { get; set; }
        public string Invoice { get; set; }
        public int CustomerId { get; set; }
        public string MemberId { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phonenumber { get; set; }
        public string PlanName { get; set; }
        public string Price { get; set; }
        public string SellerFee { get; set; }
        public string SetupFee { get; set; }
        public string DeviceFee { get; set; }
        public string Tax { get; set; }
        public string Total { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentType { get; set; }
        public string TrxStatus { get; set; }
        public string InputStatus { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? RenewedOn { get; set; }
        public DateTime? ExpiredOn { get; set; }
        public string Method { get; set; }
        public string Type { get; set; }
        public string Servicetype { get; set; }
        public string Nasporttype { get; set; }
        public string ServerName { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}
