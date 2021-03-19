using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Scan
{
    public class XSSVuln
    {
        public bool IsVulnerable { get; set; }
        public List<string> VulnerableQuery { get; set; }
    }

    public class XSS
    {

        /// <summary>
        /// check if a website is vulnerable to an XSS
        /// </summary>
        /// <param name="url">Website URL (Need Queries)</param>
        /// <returns></returns>
        public XSSVuln Check(string url, string htmlCode = "<h1>Hello World from Scan.NET</h1>")
        {
            WebClient wc = new WebClient();
            bool vulnerable = false;
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            List<string> vulnerableQuery = new List<string>();
            foreach (string item in query)
            {
                var param = query[item] + htmlCode;
                string toUrlEncode = System.Web.HttpUtility.UrlEncode(item) + "=" + System.Web.HttpUtility.UrlEncode(query[item]);

                string uue = System.Web.HttpUtility.UrlEncode(item) + "=" + System.Web.HttpUtility.UrlEncode(param);
                uriBuilder.Query = query.ToString().Replace(toUrlEncode, uue);
                string NewUrl = uriBuilder.ToString();

                string container = wc.DownloadString(NewUrl);

                if (container.Contains(htmlCode))
                {
                    vulnerable = true;

                }
                else
                {

                }

            }



            var result = new XSSVuln
            {
                IsVulnerable = vulnerable,
                VulnerableQuery = vulnerableQuery,

            };

            return result;

        }
    }
}
