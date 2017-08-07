using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ImpotsTaxes.Models
{
    public class Liste
    {
        public Liste()
        {

        }
      
        
        //LISTE DES ASSUJETTIS
        //====================
        public List<Person> AssujettiNoteMig()
        {
            ConnectionDB con = new ConnectionDB(1);
            DataTable dtt = con.Data_Source("SELECT * from "+ 
                                            "( "+
                                            "SELECT ROW_NUMBER() OVER (ORDER BY Nom_raison ASC) AS row_num,* from "+
                                            "( " +
                                            "SELECT DISTINCT  tAssujetti.NumImpot "+
                                            ",tAssujetti.Nom_raison "+
                                            ",tAssujetti.numid_nat "+
                                            ",tAssujetti.Sigle "+
                                            ",tAssujetti.telephone "+
                                            ",tAssujetti.Email "+
                                            ",tAssujetti.typepersonne "+
                                            ",tAssujetti.AdressePost "+ 
                                            ",tAssujetti.NumImpotDGI "+ 
                                            ",tAssujetti.Numero "+ 
                                            ",tAvenue.Avenue "+ 
                                            ",tQuartier.Quartier "+ 
                                            ",tCommune.Commune "+ 
                                            ",tVille.Ville "+ 
                                            ",tProvince.Province "+  
                                            "FROM  tAssujetti "+
                                            "INNER JOIN tNotePercepteur ON tAssujetti.NumImpot=tNotePercepteur.NumImpot "+
                                            "INNER JOIN tAntenne ON tNotePercepteur.IdAntenne=tAntenne.IdAntenne "+
                                            "INNER JOIN tCentre ON tAntenne.IdCentre=tCentre.IdCentre "+ 
                                            "INNER JOIN tAvenue ON tAssujetti.IdAvenue = tAvenue.IdAvenue "+ 
                                            "INNER JOIN tQuartier ON tAvenue.IdQuartier = tQuartier.IdQuartier "+ 
                                            "INNER JOIN tCommune ON dbo.tQuartier.IdCommune = tCommune.IdCommune "+ 
                                            "INNER JOIN tVille ON dbo.tCommune.IdVille = tVille.IdVille "+ 
                                            "INNER JOIN dbo.tProvince ON dbo.tVille.IdProv = tProvince.IdProv "+
                                            "WHERE tCentre.IdCentre='DG' "+
                                            "AND tNotePercepteur.IdNote NOT IN (SELECT IdNote FROM tNoteMigree) " +
                                            ") as Person " +
                                            ") as persComp " + 
                                            "where row_num>=0 and row_num<50 " +
                                            "ORDER BY Nom_raison ",
                                            "tAssujetti");
            List<Person> lst = new List<Person>();
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                lst.Add(new Person()
                {
                    nbre = i + 1,
                    Id_person = dtt.Rows[i]["NumImpot"].ToString(),
                    name_company = dtt.Rows[i]["Nom_raison"].ToString(),
                    initials = dtt.Rows[i]["Sigle"].ToString(),
                    telephone = dtt.Rows[i]["telephone"].ToString(),
                    email = dtt.Rows[i]["Email"].ToString(),
                    p_o_box = dtt.Rows[i]["AdressePost"].ToString(),
                    tax_num_dgi = dtt.Rows[i]["NumImpotDGI"].ToString(),
                    avenue = dtt.Rows[i]["Avenue"].ToString(),
                    number = dtt.Rows[i]["Numero"].ToString(),
                    quarter = dtt.Rows[i]["Quartier"].ToString(),
                    commune = dtt.Rows[i]["Commune"].ToString(),
                    town_dist = dtt.Rows[i]["Ville"].ToString()
                });
            }
            return lst;
        }

        //LISTE DES ASSUJETTIS DU NOUVEAU SYSTEME (à comparer à celui selectionné précedemment)
        //=====================================================================================

        public List<Person> lstAssujettiNS(string pnom)
        {
            string[] nom = pnom.Split(' ');

            ConnectionDB con = new ConnectionDB(2);
            DataTable dtt = con.Data_Source("SELECT * from "+ 
                                            "( "+
                                            "SELECT person.id, "+ 
                                            "physical_person.name + ' ' + physical_person.last_name + ' ' + physical_person.nick_name as Nom, "+ 
                                            "'-' AS Sigle, "+ 
                                            "'-' AS numid_nat, "+ 
                                            "'-' as tax_num_dgi, "+ 
                                            "person.email, "+ 
                                            "person.p_o_box, "+ 
                                            "person.prov, "+ 
                                            "person.town_dist, "+ 
                                            "person.commune, "+ 
                                            "person.quarter_sect, "+ 
                                            "person.avenue_loc, "+ 
                                            "person.number "+ 
                                            "FROM person "+ 
                                            "INNER JOIN physical_person ON person.id = physical_person.id "+  
                                            "union "+ 
                                            "SELECT person.id, "+ 
                                            "company.company_name as Nom, "+ 
                                            "company.initials AS Sigle, "+ 
                                            "company.numid_nat, "+ 
                                            "company.tax_num_dgi, "+ 
                                            "person.email, "+ 
                                            "person.p_o_box, "+ 
                                            "person.prov, "+ 
                                            "person.town_dist, "+ 
                                            "person.commune, "+ 
                                            "person.quarter_sect, "+ 
                                            "person.avenue_loc, "+ 
                                            "person.number "+ 
                                            "FROM person "+ 
                                            "INNER JOIN company ON person.id = company.id "+
                                            ") as Personne " +
                                            "where Nom like '%" + nom[0] + "%' and Nom like '%" + nom[1] + "%'" 
                                            ,"person");

            List<Person> lst = new List<Person>();
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                lst.Add(new Person()
                {
                    nbre = i + 1,
                    Id_person = dtt.Rows[i]["id"].ToString(),
                    name = dtt.Rows[i]["Nom"].ToString(),
                    initials = dtt.Rows[i]["Sigle"].ToString(),
                    numid_nat = dtt.Rows[i]["numid_nat"].ToString(),
                    tax_num_dgi = dtt.Rows[i]["tax_num_dgi"].ToString(),
                    email = dtt.Rows[i]["email"].ToString(),
                    p_o_box = dtt.Rows[i]["p_o_box"].ToString(),
                    province = dtt.Rows[i]["prov"].ToString(),
                    town_dist = dtt.Rows[i]["town_dist"].ToString(),
                    commune = dtt.Rows[i]["commune"].ToString(),
                    quarter = dtt.Rows[i]["quarter_sect"].ToString(),
                    avenue = dtt.Rows[i]["avenue_loc"].ToString(),
                    number = dtt.Rows[i]["number"].ToString()

                });
            }
            return lst;
        }


        //LISTE DES NOTES DE L'ASSUJETTI
        //==============================
        public List<Assessment> lstNotes(string idAssujetti)
        {
            ConnectionDB con = new ConnectionDB(1);
            DataTable dtt = con.Data_Source("select "+
                                            "IdNote, "+
                                            "CONVERT(VARCHAR(10),DateNote,103) as DateNote, " +
                                            "MontantEnChiffre, "+
                                            "Devise, "+
                                            "tArticleBudjetaire.IdArticle, "+
                                            "tArticleBudjetaire.LibelleArticle, "+
                                            "tAntenne.Designation "+
                                            "from "+ 
                                            "tNotePercepteur "+ 
                                            "INNER JOIN tAssujetti ON tNotePercepteur.NumImpot=tAssujetti.NumImpot "+
                                            "INNER JOIN tArticleBudjetaire ON tNotePercepteur.IdArticle=tArticleBudjetaire.IdArticle "+
                                            "INNER JOIN tAntenne ON tNotePercepteur.IdAntenne=tAntenne.IdAntenne " +
                                            "where tAssujetti.NumImpot='" + idAssujetti + "'"
                                            , "tNotePercepteur");

            List<Assessment> lst = new List<Assessment>();
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                lst.Add(new Assessment()
                {
                    assessment_id = dtt.Rows[i]["IdNote"].ToString(),
                    assessment_date = dtt.Rows[i]["DateNote"].ToString(),
                    amount = Convert.ToDouble(dtt.Rows[i]["MontantEnChiffre"].ToString()),
                    currency = dtt.Rows[i]["Devise"].ToString(),
                    tax_id = dtt.Rows[i]["IdArticle"].ToString(),
                    tax_name = dtt.Rows[i]["LibelleArticle"].ToString(),
                    entity_name = dtt.Rows[i]["Designation"].ToString()
                    
                });
            }
            return lst;
        }

        //CREATION DE LA LISTE DE CENTRE POUR COMPTE
        //=============================
        private List<string> lstcentre()
        {
            List<string> lstcentre = new List<string>();
            ConnectionDB con = new ConnectionDB(2);
            DataTable dtt = con.Data_Source("SELECT entity_name FROM fiscal_entity", "fiscal_entity");
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                lstcentre.Add(dtt.Rows[i]["entity_name"].ToString());
            }
            return lstcentre;
        }
        //CREATION DE LA LISTE DE CENTRE/ANTENNE
        //=============================
        private List<string> lstAnteCentre()
        {
            List<string> lstAnteCentre = new List<string>();
            ConnectionDB con = new ConnectionDB(2);
            DataTable dtt = con.Data_Source("SELECT entity_name FROM fiscal_entity", "fiscal_entity");
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                lstAnteCentre.Add(dtt.Rows[i]["entity_name"].ToString());
            }
            return lstAnteCentre;
        }
        
        //CREATION DE LA LISTE ARTICLE
        //=============================
        private List<string> lstarticle()
        {
            List<string> lstarticle = new List<string>();
            ConnectionDB conn = new ConnectionDB(2);
            DataTable dtt = conn.Data_Source("SELECT tax_id FROM tax", "tax");
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                lstarticle.Add(dtt.Rows[i]["tax_id"].ToString());
            }
            return lstarticle;
        }
        //CREATION DE LA LISTE LIBELLE
        //=============================
        private List<string> lstLibelleA()
        {
            List<string> lstLibelleA = new List<string>();
            ConnectionDB conn = new ConnectionDB(2);
            DataTable dtt = conn.Data_Source("SELECT tax_name FROM tax", "tax");
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                lstLibelleA.Add(dtt.Rows[i]["tax_name"].ToString());
            }
            return lstLibelleA;
        }
        //CREATION DE LA LISTE AGENT
        //=============================
        public List<string> lstutilisateur(string id)
        {
            List<string> lstutilisateur = new List<string>();
            ConnectionDB conn = new ConnectionDB(1);
            DataTable dtt = conn.Data_Source("SELECT  physical_person.name + ' ' + physical_person.last_name + ' ' + physical_person.nick_name as Worker FROM person INNER JOIN physical_person ON person.id = physical_person.id INNER JOIN worker ON physical_person.id = worker.id WHERE id=worker.id", "tAgent");
            
            
            
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                lstutilisateur.Add(dtt.Rows[i]["Worker"].ToString());
            }
            return lstutilisateur;
        }

    }
}