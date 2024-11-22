using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.Models
{
    public partial class Radreply
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
