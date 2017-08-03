using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ImpotsTaxes.Models
{
    public class Person
    {
        public int nbre { set; get; }
        public string Id_person { get; set; }
        public string name_company { get; set; }
        public string initials { get; set; }
        public string tax_num_dgi { get; set; }
        public string numid_nat { get; set; }
        public string name { get; set; }
        public string last_name {get;set;}
        public string nick_name {get;set;}
        public string p_o_box { get; set; }
        public string email { get; set; }
        public string province { get; set; }
        public string town_dist { get; set; }
        public string commune { get; set; }
        public string quarter { get; set; }
        public string avenue { get; set; }
        public string number { get; set; }
        public string telephone { get; set; }
        public string entite { get; set; }
        public int rank { get; set; }
        public string employee_function { get; set; }
        public string employee_grade { get; set; }
        public string employee_grade_id { get; set; }
                
    }
}