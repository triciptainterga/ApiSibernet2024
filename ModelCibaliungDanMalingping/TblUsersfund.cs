using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.ModelCibaliungDanMalingping
{
    public partial class TblUsersfund
    {
        public int Id { get; set; }
        public string Invoice { get; set; }
        public int Userid { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phonenumber { get; set; }
        public string TotalTopup { get; set; }
        public string FundsType { get; set; }
        public string FundsStatus { get; set; }
        public string TopupPayment { get; set; }
        public DateTime? TopupDate { get; set; }
        public DateTime? ActiveDate { get; set; }
        public string PaymentMethod { get; set; }
        public string TrxType { get; set; }
        public int Debit { get; set; }
        public int Credit { get; set; }
        public int FundsB { get; set; }
        public int FundsN { get; set; }
        public int? AdminId { get; set; }
        public string AdminName { get; set; }
    }
}
