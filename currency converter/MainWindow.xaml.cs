using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace currency_converter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<currency> _base_currencies;
        List<currency> _quote_currencies;

        public MainWindow()
        {
            InitializeComponent();
            #region Remplissage des comboboxs

            _base_currencies =  new List<currency>();
            _base_currencies.Add(new currency("btc-bitcoin", "Bitcoin", "BTC"));
            _base_currencies.Add(new currency("eur-euro-token", "Euro Token", "EUR"));
            _base_currencies.Add(new currency("ncc-neurochain", "NeuroChain", "NCC"));
            _base_combo.ItemsSource = _base_currencies;
            _base_combo.DisplayMemberPath = "Currency_name";
            _base_combo.SelectedValuePath = "Currency_id";
            _base_combo.SelectedIndex = 0;

            _quote_currencies = new List<currency>();
            _quote_currencies.Add(new currency("usdc-usd-coin", "USD Coin", "USDC"));
            _quote_currencies.Add(new currency("eth-ethereum", "Ethereum", "ETH"));
            _quote_currencies.Add(new currency("xrp-xrp", "XRP", "XRP"));
            _quote_combo.ItemsSource = _quote_currencies;
            _quote_combo.DisplayMemberPath = "Currency_name";
            _quote_combo.SelectedValuePath = "Currency_id";
            _quote_combo.SelectedIndex = 0;
            #endregion

        }
 
        private void _base_combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (currency item in _base_currencies)
            {
                if (_base_combo.SelectedValue.ToString().CompareTo(item.Currency_id)== 0)
                    _label_symb.Content = _base_currencies[_base_currencies.IndexOf(item)].Currency_symbol;
            }
        }

        private  void ConvertBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int amount;
                if (_txtbx_amount.Text.CompareTo(String.Empty) == 0)
                    throw new Exception("amount field is required");
                if (!int.TryParse(_txtbx_amount.Text, out amount))
                    throw new Exception("amount field must be integer");
                ConvertionResult r = currency.Convert(_base_combo.SelectedValue.ToString(), _quote_combo.SelectedValue.ToString(), amount);
                if (r != null)
                {
                    int int_result = int.Parse(r.Price.ToString().Substring(0, r.Price.ToString().IndexOf('.')));
                    _label_result_int.Content = int_result;
                    _label_result_float.Content = r.Price.ToString().Substring(r.Price.ToString().IndexOf('.'), 4);
                    _detail_result.Content = amount + " " + ((currency)_base_combo.SelectedItem).Currency_symbol + " is equal " + r.Price + " of " + ((currency)_quote_combo.SelectedItem).Currency_symbol;
                }
            }
            catch (Exception ex)
            {
                _txtbx_amount.Text = String.Empty;
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void RaduitBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
