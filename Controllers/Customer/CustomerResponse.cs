using System;
using System.Collections.Generic;

namespace WebApiReport.Controllers.Customer
{
    public class CustomerResponse
    {
        public int Id { get; set; }
        public string Site { get; set; }
        public string MemberId { get; set; }
        public string Type { get; set; }
        public string Servicetype { get; set; }
        public string Method { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public string PlanName { get; set; }
        public DateTime? RenewedOn { get; set; }
        public DateTime? ExpiredOn { get; set; }
        public string LocalAddress { get; set; }
        public string TrxInvoice { get; set; }
        public string TrxStatus { get; set; }
        public string PaymentType { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    public partial class TblCustomerResponse
    {
        public int Id { get; set; }
        public string Site { get; set; }
        public string MemberId { get; set; }
        public string Secret { get; set; }
        public string Type { get; set; }
        public string Servicetype { get; set; }
        public string Nasporttype { get; set; }
        public string ServerName { get; set; }
        public string Method { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string IdentityNumber { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string PlanName { get; set; }
        public string Price { get; set; }
        public string SellerFee { get; set; }
        public string SetupFee { get; set; }
        public string DeviceFee { get; set; }
        public string Tax { get; set; }
        public string Total { get; set; }
        public DateTime? RenewedOn { get; set; }
        public DateTime? ExpiredOn { get; set; }
        public DateTime? LastLogin { get; set; }
        public string LocalAddress { get; set; }
        public string RemoteAddress { get; set; }
        public string Note { get; set; }
        public string SmsAlert { get; set; }
        public string EmailAlert { get; set; }
        public string WaAlert { get; set; }
        public string TrxInvoice { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string TrxStatus { get; set; }
        public string PaymentType { get; set; }
        public string PaymentStatus { get; set; }
        public string InputStatus { get; set; }
        public string AuthStatus { get; set; }
        public string BindMac { get; set; }
        public string MacAddress { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
    }

}
