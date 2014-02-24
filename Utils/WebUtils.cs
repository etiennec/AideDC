using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Aide_Dilicom3.Utils
{
    class WebUtils
    {
        public static string getCleansedUrl(string url)
        {
            string protocol = "http";
            string server = "";
            string port = "";
            Match m = Regex.Match(url, @"(?<protocol>(http|https)://)?(?<server>[^:/]+)(?<port>:\d+)?", RegexOptions.None);

            if (!m.Success)
            {
                return "";
            }
            else
            {
                protocol = "".Equals(m.Groups["protocol"].Value) ? protocol : m.Groups["protocol"].Value;
                server = m.Groups["server"].Value;
                port = m.Groups["port"].Value;
            }
            return protocol + server + port;
        }
    }
}
