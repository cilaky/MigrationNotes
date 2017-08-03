using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ImpotsTaxes.Models
{
    public class Assessment
    {
        public string assessment_id { get; set; }
        public string tax_id { get; set; }
        public string tax_name { get; set; }
        public string taxpayer_id { get; set; }
        public string taxpayer_name { get; set; }
        public string taxpayer_address { get; set; }
        public string taxman_id { get; set; }
        public string taxman_name { get; set; }
        public string entity_id { get; set; }
        public string entity_name { get; set; }
        public string assessment_date { get; set; }
        public string place { get; set; }
        public string taxation_base { get; set; }
        public string taxation_base_id { get; set; }
        public string text_reference { get; set; }
        public double amount { get; set; }
        public string currency { get; set; }
        public string amount_in_words { get; set; }
        public string on_account_of { get; set; }
        public double exchange_rate { get; set; }
        public int IdService { get; set; }
        public string payment_date { get; set; }
        public string receipt_date { get; set; }
        public string banker_id { get; set; }
        public string bank_id { get; set; }
        public string receipt_number { get; set; }
        public double amount_payment { get; set; }
        public string currency_payment { get; set; }
        public string amount_in_words_payment { get; set; }
        public double exchange_rate_payment { get; set; }
        public string validation_date { get; set; }
        public string validator_id { get; set; }
        public string validator_name { get; set; }
        public string notice { get; set; }
        public double amount_validation { get; set; }
        public string currency_validation { get; set; }
        public double amount_validation_FC { get; set; }
        public double amount_validation_USD { get; set; }
        public string amount_in_words_validation { get; set; }        
        public string descript { get; set; }
        public string note { get; set; }
        public DateTime saving_date { get; set; }
        public string userId { get; set; }
        public int printed { get; set; }
        public Adress adresse = new Adress();
        public Person taxPayer = new Person();
        public string discharger { get; set; }  //Apureur
        public string bank { get; set; }

    }

    
}
