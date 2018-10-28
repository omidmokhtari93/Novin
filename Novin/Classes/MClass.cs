using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Novin
{
    public class BimeInfo
    {
        public string IdCode { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Person { get; set; }
        public string Total { get; set; }
        public string Date { get; set; }
    }

    public class CustomerInformation
    {
        public string Person { get; set; }
        public string PerType { get; set; }
        public string OrType { get; set; }
        public string EcCode { get; set; }
        public string NaCode { get; set; }
        public string OrCode { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}