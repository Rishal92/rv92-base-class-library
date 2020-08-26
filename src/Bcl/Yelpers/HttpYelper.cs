using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bcl.Yelpers
{
    public static class HttpYelper
    {
        public static string ToQueryString(this Dictionary<string, object> nvc)
        {
            var array = (from key in nvc.Keys select $"{HttpUtility.UrlEncode(key)}={HttpUtility.UrlEncode(nvc[key].ToString())}").ToArray();

            return "&" + string.Join("&", array);
        }
    }
}