using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.ModelPanembong
{
    public partial class Radcheck
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Attribute { get; set; }
        public string Op { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public string Method { get; set; }
    }
}
