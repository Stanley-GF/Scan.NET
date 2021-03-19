using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Scan
{
    /// <summary>
    /// do not care this ok?? i'm too lazy to learn params of a class etc
    /// </summary>
    public class SQLVuln
    {
        public bool IsVulnerable { get; set; }
        public List<string> VulnerableQuery { get; set; }
    }


    //Credit to RainbowSQL
    public class SQL
    {
        
        public SQL()
        {
            

        }


        public static string[] SQLError = { "mysql_fetch", "SQL syntax", "ORA-01756", "OLE DB Provider for SQL Server", "SQLServer JDBC Driver", "Error Executing Database Query" };
        

        

        /// <summary>
        /// Check if a website is vulnerable.
        /// </summary>
        /// <param name="url">Website url, removing the last query : localhost/book-id?q=</param>
        /// <returns></returns>
        public SQLVuln Check(string url)
        {

            List<string> vulnerablequery = new List<string>();

            WebClient wc = new WebClient();

            bool vulnerable = false;


            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            foreach (string item in query)
            {
                var param = query[item] + "'";
                string toUrlEncode = System.Web.HttpUtility.UrlEncode(item) + "=" + System.Web.HttpUtility.UrlEncode(query[item]);

                string uue= System.Web.HttpUtility.UrlEncode(item) + "=" + System.Web.HttpUtility.UrlEncode(param);
                uriBuilder.Query = query.ToString().Replace(toUrlEncode, uue);
                string NewUrl = uriBuilder.ToString();

                string container = wc.DownloadString(NewUrl);

                if (SQLError.Any(c => container.Contains(c)))
                {
                    vulnerable = true;
                    vulnerablequery.Add(item);
                }
                else
                {

                }

                
            }
            var result = new SQLVuln
            {
                IsVulnerable = vulnerable,
                VulnerableQuery = vulnerablequery,

            };
            return result;
        }


    }
}
