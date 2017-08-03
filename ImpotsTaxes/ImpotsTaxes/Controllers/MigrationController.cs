using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImpotsTaxes.Models;
using System.Data;

namespace ImpotsTaxes.Controllers
{
    public class MigrationController : Controller
    {
        //
        // GET: /Migration/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Assujetti()
        {
            //List<Person> lst = new List<Person>();
            Liste lst = new Liste();
            ViewBag.Assujetti = lst.AssujettiNoteMig();
            return View();
        }

        public ActionResult SelectionAssujetti()
        {
            return View();
        }

        public ActionResult NotePerception()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AffichageNote()
        {
            ConnectionDB con = new ConnectionDB(1);
            DataTable dtt = new DataTable();
            dtt = con.Data_Source("SELECT tNotePercepteur.IdNote as assessment_id, "+ 
                                    "tNotePercepteur.NumImpot as id, "+ 
                                    "tAntenne.Designation as entity_name, "+ 
                                    "tNotePercepteur.DateNote as assessment_date, "+ 
                                    "tNotePercepteur.TerritoireVille as place, "+ 
                                    "tNotePercepteur.NoteDebit as taxation_base, "+ 
                                    "'' as taxation_base_id, "+ 
                                    "tNotePercepteur.TauxReference as text_reference, "+ 
                                    "tNotePercepteur.MontantEnChiffre as amount, "+ 
                                    "tNotePercepteur.Devise as currency, "+ 
                                    "tNotePercepteur.MontantEnLettre as amount_in_words, "+ 
                                    "case when (SELECT case when Nom_raison IS null then tNotePercepteur.PostNom else Nom_raison end from tAssujetti WHERE NumImpot=tNotePercepteur.PostNom) IS null then tAssujetti.Nom_raison else "+ 
                                    "(SELECT case when Nom_raison IS null then tNotePercepteur.PostNom else Nom_raison end from tAssujetti WHERE NumImpot=tNotePercepteur.PostNom) end "+
                                    "AS Name_on_account_of, "+ 
                                    "tNotePercepteur.TauxEchange as exchange_rate, "+ 
                                    "tAssujetti.Nom_raison AS PayerName, "+ 
                                    "tAssujetti.AdressePost as p_o_box, "+ 
                                    "tProvince.Province as prov, "+ 
                                    "tVille.Ville as town_dist, "+ 
                                    "tCommune.Commune as commune, "+ 
                                    "tQuartier.Quartier as quarter_sect, "+ 
                                    "tAvenue.Avenue as avenue_loc, "+ 
                                    "tAssujetti.Numero as number, "+ 
                                    "(SELECT  Nom + ' ' + PostNom + ' ' + Prenom  FROM  tAgent WHERE   IdAgent = tNotePercepteur.IdTaxateur) AS NameTaxman, "+ 
                                    "tAssujetti.Email as email, "+ 
                                    "tArticleBudjetaire.IdArticle AS Tax, "+ 
                                    "tArticleBudjetaire.LibelleArticle as tax_name, "+ 
                                    "tNotePercepteur.DateVisa as validation_date, "+ 
                                    "tNotePercepteur.AvisMotive as notice, "+ 
                                    "tNotePercepteur.MontantViseEnChiffre AS Amount_Valid, "+ 
                                    "tNotePercepteur.MontantViseEnLettre AS amount_in_validation, "+ 
                                    "tNotePercepteur.Devise AS currency_validation, "+ 
                                    "(SELECT  Nom + ' ' + PostNom + ' ' + Prenom  FROM  tAgent WHERE   IdAgent = tNotePercepteur.IdOrdonnateur) AS Validator, "+ 
                                    "case when tPaiementNote.DatePriseEcharge is null then ' ' else tPaiementNote.DatePriseEcharge end as payment_date, "+ 
                                    "case when tPaiementNote.IdBanque is null then '' else tPaiementNote.IdBanque end as bank, "+
                                    "case when (SELECT  Nom + ' ' + PostNom + ' ' + Prenom  FROM  tAgent WHERE   IdAgent = tPaiementNote.IdComptable) is null then ' ' else "+
                                    "(SELECT  Nom + ' ' + PostNom + ' ' + Prenom  FROM  tAgent WHERE   IdAgent = tPaiementNote.IdComptable) end AS Comptable, "+ 
                                    "case when tPaiementNote.Bordereau is null then '' else tPaiementNote.Bordereau end as receipt_number, "+ 
                                    "case when tPaiementNote.Espece is null then 0 else tPaiementNote.Espece end as payment_amount, "+ 
                                    "case when tPaiementNote.DevisePaiement is null then '' else tPaiementNote.DevisePaiement end as payment_currency, "+ 
                                    "case when tPaiementNote.EnLettre is null then '' else tPaiementNote.EnLettre end as payment_in_words, "+ 
                                    "case when tPaiementNote.DateVersement is null then '' else tPaiementNote.DateVersement end as receipt_date, "+ 
                                    "'-' as descript "+ 
                                    "FROM  tNotePercepteur "+
                                    "INNER JOIN tAssujetti ON tNotePercepteur.NumImpot=tAssujetti.NumImpot "+
                                    "INNER JOIN tArticleBudjetaire ON tNotePercepteur.IdArticle=tArticleBudjetaire.IdArticle "+
                                    "INNER JOIN tAntenne ON tNotePercepteur.IdAntenne=tAntenne.IdAntenne "+ 
                                    "INNER JOIN tAvenue ON tAssujetti.IdAvenue=tAvenue.IdAvenue "+
                                    "INNER JOIN tQuartier ON tAvenue.IdQuartier=tQuartier.IdQuartier "+
                                    "INNER JOIN tCommune ON tQuartier.IdCommune=tCommune.IdCommune "+
                                    "INNER JOIN tVille ON tCommune.IdVille=tVille.IdVille "+
                                    "INNER JOIN tProvince ON tVille.IdProv=tProvince.IdProv "+
                                    "LEFT JOIN tPaiementNote ON tNotePercepteur.IdNote=tPaiementNote.IdNote "+
                                    "WHERE " + 
                                    "tNotePercepteur.IdNote = '" + Request.Params["note"] + "' "
                                    , "tax_assessment");
            Assessment ass = new Assessment()
            {
                assessment_id = dtt.Rows[0]["assessment_id"].ToString(),
                assessment_date = Convert.ToDateTime(dtt.Rows[0]["assessment_date"].ToString()).ToString("dd/MM/yyyy"),
                entity_name = dtt.Rows[0]["entity_name"].ToString(),
                taxation_base = dtt.Rows[0]["taxation_base"].ToString(),
                taxation_base_id = dtt.Rows[0]["taxation_base_id"].ToString(),
                taxpayer_name = dtt.Rows[0]["PayerName"].ToString(),
                tax_name = dtt.Rows[0]["tax_name"].ToString(),
                on_account_of = dtt.Rows[0]["Name_on_account_of"].ToString(),
                tax_id = dtt.Rows[0]["Tax"].ToString(),
                adresse = new Adress()
                {
                    town_dist = dtt.Rows[0]["town_dist"].ToString(),
                    commune = dtt.Rows[0]["commune"].ToString(),
                    quarter_sect = dtt.Rows[0]["quarter_sect"].ToString(),
                    avenue_loc = dtt.Rows[0]["avenue_loc"].ToString(),
                    number = dtt.Rows[0]["number"].ToString()
                },
                text_reference = dtt.Rows[0]["text_reference"].ToString(),
                amount = Convert.ToDouble(dtt.Rows[0]["amount"].ToString()),
                currency = dtt.Rows[0]["currency"].ToString(),
                amount_in_words = dtt.Rows[0]["amount_in_words"].ToString(),
                taxman_name = dtt.Rows[0]["NameTaxman"].ToString(),
                taxPayer = new Person()
                {
                    p_o_box = dtt.Rows[0]["p_o_box"].ToString(),
                    email = dtt.Rows[0]["email"].ToString()
                },
                validation_date = Convert.ToDateTime(dtt.Rows[0]["validation_date"].ToString()).ToString("dd/MM/yyyy"),
                notice = dtt.Rows[0]["notice"].ToString(),
                amount_validation = Convert.ToDouble(dtt.Rows[0]["Amount_Valid"].ToString()),
                amount_in_words_validation = dtt.Rows[0]["amount_in_validation"].ToString(),
                currency_validation = dtt.Rows[0]["currency_validation"].ToString(),
                validator_name = dtt.Rows[0]["Validator"].ToString(),
                payment_date = Convert.ToDateTime(dtt.Rows[0]["payment_date"].ToString()).ToString("dd/MM/yyyy HH:mm:ss"),
                discharger = dtt.Rows[0]["Comptable"].ToString(),
                bank = dtt.Rows[0]["bank"].ToString(),
                receipt_number = dtt.Rows[0]["receipt_number"].ToString(),
                receipt_date = dtt.Rows[0]["receipt_date"].ToString(),
                amount_payment = Convert.ToDouble(dtt.Rows[0]["payment_amount"].ToString()),
                currency_payment = dtt.Rows[0]["payment_currency"].ToString(),
                amount_in_words_payment = dtt.Rows[0]["payment_in_words"].ToString(),
                descript = dtt.Rows[0]["descript"].ToString()
            };
            ViewBag.note = ass;
            return View();
        }

        public ActionResult Migrer()
        {
            return View();
        }
    }
}
