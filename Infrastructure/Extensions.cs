using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class Extensions
    {
        public static string RemoveTrailingSlash(this string value) => value.EndsWith("/") ? value.TrimEnd('/') : value;
    }
}
