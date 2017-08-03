using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ImpotsTaxes.Models
{
    public class FiscalEntity
    {
        public int nbre { set; get; }
        public string entity_id { set; get; }
        public string initials { set; get; }
        public string entity_name { set; get; }
        public string prov { set; get; }
        public string town_dist { set; get; }
        public string commune { set; get; }
        public string quarter_sect { set; get; }
        public string avenue_loc { set; get; }
        public string number { set; get; }
        public string email { set; get; }
        public string telephone { set; get; }
        public string rank { set; get; }
        public string chief_entity { set; get; }

        
    }
}