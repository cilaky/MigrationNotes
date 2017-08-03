using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ImpotsTaxes.Models
{
    public class Tax
    {
        public string tax_id { set; get; }
        public string tax_name { set; get; }
        public string generating_fact { set; get; }
        public string periodicity { set; get; }
               
    }
}