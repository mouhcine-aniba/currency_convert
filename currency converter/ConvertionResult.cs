using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace currency_converter
{
    class ConvertionResult
    {
        private string base_currency_id;
        private string base_currency_name;
        private DateTime base_price_last_updated;
        private string quote_currency_id;
        private string qoute_currency_name;
        private DateTime quote_price_last_updated;
        private int amount;
        private double price;

        public string Base_Currency_name { get => base_currency_name; set => base_currency_name = value; }
        public string Base_Currency_id { get => base_currency_id; set => base_currency_id = value; }
        public DateTime Base_price_last_updated { get => base_price_last_updated; set => base_price_last_updated = value; }
        public string Quote_currency_id { get => quote_currency_id; set => quote_currency_id = value; }
        public string Qoute_currency_name { get => qoute_currency_name; set => qoute_currency_name = value; }
        public DateTime Quote_price_last_updated { get => quote_price_last_updated; set => quote_price_last_updated = value; }
        public int Amount { get => amount; set => amount = value; }
        public double Price { get => price; set => price = value; }
    }
}
