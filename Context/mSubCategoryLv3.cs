using System;

namespace WebApiReport.Context
{
   
    public class SubCategoryLv3
    {
        public int ID { get; set; }
        public string CustomerID { get; set; }
        public string IDKamus { get; set; }
        public string CategoryID { get; set; }
        public string SubCategory1ID { get; set; }
        public string SubCategory2ID { get; set; }
        public string SubCategory3ID { get; set; }
        public string SubName { get; set; }
        public string Description { get; set; }
        public string TujuanEskalasi { get; set; }
        public string Priority { get; set; }
        public string Severity { get; set; }
        public string NA { get; set; }
        public int? SLA { get; set; }
        public string ReasonCode { get; set; }
        public string Response_Agent { get; set; }
        public string Status_Customer { get; set; }
        public string Version { get; set; }
        public DateTime? Contract_Startdate { get; set; }
        public DateTime? Contract_Enddate { get; set; }
        public string License { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserUpdate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string Layer { get; set; }
    }

}
