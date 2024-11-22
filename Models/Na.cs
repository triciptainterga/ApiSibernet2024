using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiReport.Models
{
    public partial class Na
    {
        public int Id { get; set; }
        public string Nasname { get; set; }
        public string Shortname { get; set; }
        public string Type { get; set; }
        public int? Ports { get; set; }
        public string Secret { get; set; }
        public int ApiPort { get; set; }
        public string ApiUsername { get; set; }
        public string ApiPassword { get; set; }
        public string RedirectUrl { get; set; }
        public string Timezone { get; set; }
        public string Region { get; set; }
        public string Server { get; set; }
        public string Community { get; set; }
        public string Description { get; set; }
    }
}
