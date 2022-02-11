using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using Newtonsoft.Json;

namespace currency_converter
{
    class currency
    {
        private string currency_id;
        private string currency_name;
        private string currency_symbol;

        public string Currency_symbol { get => currency_symbol; set => currency_symbol = value; }
        public string Currency_name { get => currency_name; set => currency_name = value; }
        public string Currency_id { get => currency_id; set => currency_id = value; }

        public currency()
        {
        }

        public currency(string currency_id, string currency_name, string currency_symbol)
        {
            this.currency_id = currency_id;
            this.currency_name = currency_name;
            this.currency_symbol = currency_symbol;
        }

        public static ConvertionResult Convert(String base_currency ,String quote_currency , int amount)
        {
            try
            {
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create($"https://api.coinpaprika.com/v1/price-converter?base_currency_id={base_currency}&quote_currency_id={quote_currency}&amount=" + amount);
                myReq.Method = "GET";
                myReq.Timeout = 6000;
                myReq.ContentType = "application/json";
                HttpWebResponse resp =(HttpWebResponse) myReq.GetResponse();
                string myResponse = String.Empty;
                using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                {
                    myResponse = sr.ReadToEnd();
                }
                ConvertionResult result = JsonConvert.DeserializeObject<ConvertionResult>(myResponse);
                if(result == null)
                {
                Dictionary<String,String>  iserror = JsonConvert.DeserializeObject<Dictionary<String, String>>(myResponse);
                    throw new Exception(iserror["error"].ToString());
                }
                
                return result;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
    }
}
