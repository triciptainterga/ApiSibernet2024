using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.Models
{
    public partial class TblUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string IdentityNumber { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public string UserType { get; set; }
        public string ProfileImg { get; set; }
        public string Permission { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime Creationdate { get; set; }
        public string TopupSystem { get; set; }
        public int? Funds { get; set; }
        public string FundsType { get; set; }
        public string FundsStatus { get; set; }
        public string TopupPayment { get; set; }
        public DateTime? TopupDate { get; set; }
        public string Invoice { get; set; }
        public string PaymentStatus { get; set; }
    }
}
