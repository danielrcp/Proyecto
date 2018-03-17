using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Helper
{
    public static class IpHelper
    {
        public static string GetIPHelper()
        {
            string ip = HttpContext.Current.Request.UserHostAddress;
            return ip;
        }
    }
}
