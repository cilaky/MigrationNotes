using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpotsTaxes.Models
{
   public class Adress
    {
       public int nbre { get; set; }
        public string prov { get; set; }
        public string town_dist { get; set; }
        public string commune { get; set; }
        public string quarter_sect { get; set; }
        public string avenue_loc { get; set; }
        public string number { get; set; }
        public int rank_id { get; set; }
        public string rank_description { get; set; }

        //Accessors for Modification
        public string prov_mod { get; set; }
        public string town_dist_mod { get; set; }
        public string commune_mod { get; set; }
        public string quarter_sect_mod { get; set; }
        public string avenue_loc_mod { get; set; }
        public int rank_id_mod { get; set; }
        public string rank_description_mod { get; set; }

        public string addres { get; set; }

       /*
        // save data in the tables 
        //----------------------------------------
        public void save_prov()
        {
            DBConnection con = new DBConnection();
            con.Execute_Query("INSERT INTO province values ('" + prov + "')");
        }
        public void save_town_district()
        {
            DBConnection con = new DBConnection();
            con.Execute_Query("INSERT INTO town_district values ('" + prov + "','" + town_dist + "')");
        }
        public void save_commune()
        {
            DBConnection con = new DBConnection();
            con.Execute_Query("INSERT INTO commune  values ('" + prov + "','" + town_dist + "','" + commune + "')");

        }
        public void save_quarter_sector()
        {
            DBConnection con = new DBConnection();
            con.Execute_Query("INSERT INTO quarter_sector values ('" + prov + "','" + town_dist + "','" + commune + "','" + quarter_sect + "')");
        }
        public void save_avenue_locality()
        {
            DBConnection con = new DBConnection();
            con.Execute_Query("INSERT INTO avenue_locality values ('" + prov + "','" + town_dist + "','" + commune + "','" + quarter_sect + "','" + avenue_loc + "')");
        }
        public void save_adress()
        {
            DBConnection con = new DBConnection();
            con.Execute_Query("INSERT INTO adress values ('" + prov + "','" + town_dist + "','" + commune + "','" + quarter_sect + "','" + avenue_loc + "','+ number + ','" + rank_id + "')");
        }
        public void save_raking()
        {
            DBConnection con = new DBConnection();
            con.Execute_Query("INSERT INTO ranking values ('" + rank_id + "','" + rank_description + "')");
        }
        // modification of data in the tables 
        //----------------------------------------
        public void modify_prov()
        {
            DBConnection con = new DBConnection();
            con.Execute_Query("UPDATE province SET prov='" + prov_mod + "' WHERE prov='" + prov + "'");
        }
               
        public void modify_town_district()
        {
            DBConnection con = new DBConnection();
            con.Execute_Query("UPDATE town_district SET town_dist='" + town_dist_mod + "' WHERE town_dist='" + town_dist + "' and prov='" + prov + "'");
        }

        public void modify_commune()
        {
            DBConnection con = new DBConnection();
            con.Execute_Query("UPDATE commune SET commune='" + commune_mod + "' where commune='" + commune + "' and prov='" + prov + "' and town_dist='" + town_dist + "'");
        }
        public void modify_quarter_sector()
        {
            DBConnection con = new DBConnection();
            con.Execute_Query("UPDATE quarter_sector SET quarter_sect='" + quarter_sect_mod + "' where quarter_sect='" + quarter_sect + "' and prov='" + prov + "' and town_dist='" + town_dist + "' and commune='" + commune + "'");
        }
        public void modify_avenue_locality()
        {
            DBConnection con = new DBConnection();
            con.Execute_Query("UPDATE avenue_locality SET avenue_loc='" + avenue_loc_mod + "' where avenue_loc='" + avenue_loc + "' and prov='" + prov + "'and town_dist='" + town_dist + "'and commune='" + commune + "' and quarter_sect='" + quarter_sect + "'");
        }
        public void modify_ranking()
        {
            DBConnection con = new DBConnection();
            con.Execute_Query("UPDATE ranking SET rank_description='" + rank_description_mod + "' where rank_id='" + rank_id + "'");
        }
        //// Delete data in the tables 
        //----------------------------------------
        public void Delete_prov(string pprov)
        {
            DBConnection con = new DBConnection();
            con.Execute_Query("DELETE prov SET prov='" + pprov + "'");
        }

        public void Delete_town(string ptown_dist)
        {
            DBConnection con = new DBConnection();
            con.Execute_Query("DELETE town_district SET town_dist='" + ptown_dist + "'");
        }
        public void Delete_commune(string pcommune)
        {
            DBConnection con = new DBConnection();
            con.Execute_Query("DELETE commune SET commune='" + pcommune + "'");
        }
        public void Delete_quarter_sect(string pquarter_sect)
        {
            DBConnection con = new DBConnection();
            con.Execute_Query("DELETE quarter_sector SET quarter_sect='" + pquarter_sect + "'");
        }
        public void Delete_avenue_locality(string pavenue_loc)
        {
            DBConnection con = new DBConnection();
            con.Execute_Query("DELETE avenue_locality SET avenue_loc='" + pavenue_loc + "'");
        }
       */
    }
}
