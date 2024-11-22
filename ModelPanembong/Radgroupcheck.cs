using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.ModelPanembong
{
    public partial class Radgroupcheck
    {
        public int Id { get; set; }
        public string Groupname { get; set; }
        public string Attribute { get; set; }
        public string Op { get; set; }
        public string Value { get; set; }
        public int PlanId { get; set; }
    }
}
