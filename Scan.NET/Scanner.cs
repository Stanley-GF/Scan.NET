using Scan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scan
{
    public class Scanner
    {
        
        public SQL SQL { get; set; }

        public XSS XSS { get; set; }
        public Scanner()
        {
            SQL = new SQL();
            XSS = new XSS();
        }
    }
}
