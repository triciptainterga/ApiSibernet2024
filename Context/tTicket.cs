using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiReport.Context
{
    public partial class tTicket
    {


        public int ID { get; set; }
        public string NIK { get; set; }
        public string TicketNumber { get; set; }

        public string GroupTicketNumber { get; set; }

        public string Channel_Code { get; set; }

        public string UnitID { get; set; }

        public string TicketSource { get; set; }

        public string TicketSourceName { get; set; }

        public string TicketGroup { get; set; }

        public string TicketGroupName { get; set; }

        public string ComplaintLevel { get; set; }

        public string CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string SubCategory1ID { get; set; }

        public string SubCategory1Name { get; set; }

        public string SubCategory2ID { get; set; }

        public string SubCategory2Name { get; set; }

        public string SubCategory3ID { get; set; }

        public string SubCategory3Name { get; set; }

        public string DetailComplaint { get; set; }

        public string ResponComplaint { get; set; }

        public DateTime? DateAgentResponse { get; set; }

        public int? SLAResponseAgent { get; set; }

        public int SLA { get; set; }

        public string Severity { get; set; }

        public string Status { get; set; }

        public string UserCreate { get; set; }

        public DateTime? DateCreate { get; set; }

        public string UserSolved { get; set; }

        public DateTime? DateSolved { get; set; }

        public string UserClose { get; set; }

        public DateTime? DateClose { get; set; }

        public string TicketPosition { get; set; }

        public string ClosedBy { get; set; }

        public string KirimEmail { get; set; }

        public string KirimEmailLayer { get; set; }

        public string NA { get; set; }

        public DateTime? DateCreateReal { get; set; }

        [StringLength(50)]
        public string OverClockSystem { get; set; }

        [StringLength(500)]
        public string Dispatch_user { get; set; }

        public DateTime? Dispatch_tgl { get; set; }

        [StringLength(50)]
        public string Divisi { get; set; }

        public DateTime? Dispatch_divisi_tgl { get; set; }


    }
}
