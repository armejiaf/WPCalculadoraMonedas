using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Threading;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SimpleCurrencyConverter.Resources;

namespace SimpleCurrencyConverter
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            List<string> country = new List<string>();
            country.Add("USD");
            country.Add("EUR");
            country.Add("GBP");
            country.Add("JPY");
            country.Add("AFN");
            country.Add("ALL");
            country.Add("DZD");
            country.Add("ARS");
            country.Add("AUD");
            country.Add("BSD");
            country.Add("BHD");
            country.Add("BDT");
            country.Add("BBD");
            country.Add("BMD");
            country.Add("BRL");
            country.Add("BGN");
            country.Add("CAD");
            country.Add("XOF");
            country.Add("XAF");
            country.Add("XPF");
            country.Add("CLP");
            country.Add("CNY");
            country.Add("COP");
            country.Add("CRC");
            country.Add("HRK");
            country.Add("CYP");
            country.Add("CZK");
            country.Add("DKK");
            country.Add("DOP");
            country.Add("XCD");
            country.Add("EGP");
            country.Add("EEK");
            country.Add("FJD");
            country.Add("HKD");
            country.Add("HUF");
            country.Add("ISK");
            country.Add("XDR");
            country.Add("INR");
            country.Add("IDR");
            country.Add("IRR");
            country.Add("IQD");
            country.Add("ILS");
            country.Add("JMD");
            country.Add("JOD");
            country.Add("KZT");
            country.Add("KES");
            country.Add("KWD");
            country.Add("LBP");
            country.Add("MYR");
            country.Add("MTL");
            country.Add("MUR");
            country.Add("MXN");
            country.Add("MAD");
            country.Add("NZD");
            country.Add("NGN");
            country.Add("NOK");
            country.Add("OMR");
            country.Add("PKR");
            country.Add("XPD");
            country.Add("PEN");
            country.Add("PHP");
            country.Add("PLN");
            country.Add("QAR");
            country.Add("RON");
            country.Add("RUB");
            country.Add("SAR");
            country.Add("XAG");
            country.Add("SGD");
            country.Add("ZAR");
            country.Add("KRW");
            country.Add("LKR");
            country.Add("SDG");
            country.Add("SEK");
            country.Add("CHF");
            country.Add("TWD");
            country.Add("THB");
            country.Add("TTD");
            country.Add("TND");
            country.Add("TRY");
            country.Add("AED");
            country.Add("VEF");
            country.Add("VND");
            country.Add("ZMK");
            ddlFrom.ItemsSource = country;
            ddlTo.ItemsSource = country;
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }
        public string response { get; set; }
        private void btnRateExchange_Click(object sender, RoutedEventArgs e)
        {
            decimal amount = 0; string fromCurrency; string toCurrency;
            amount = decimal.Parse(txtAmount.Text);
            fromCurrency = ddlFrom.SelectedItem.ToString();
            toCurrency = ddlTo.SelectedItem.ToString();
            if (amount != 0)
            {
                try
                {
                    WebClient web = new WebClient();
                    web.DownloadStringCompleted +=  new DownloadStringCompletedEventHandler(StringDownloadCompleted);
                    web.DownloadStringAsync(new Uri(string.Format("http://www.google.co.in/ig/calculator?hl=en&q={2}{0}%3D%3F{1}", fromCurrency, toCurrency, amount)));            
                    Regex regex = new Regex("rhs: \\\"(\\d*.\\d*)");
                    decimal rate = System.Convert.ToDecimal(regex.Match(response).Groups[1].Value);
                    Thread.Sleep(50000);
                    lblMessage.Text = "Real-Time Rate: 1 " + ddlFrom.SelectedItem.ToString() + " = " + rate + " " + ddlTo.SelectedItem.ToString();

                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Internal error or Check Internet Connection";
                }
            }
        }
        private void StringDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                response=e.Result;
                Console.WriteLine(response);
            }
            catch (Exception ex)
            {
                response = "";
            }
        }

        private void txtAmount_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {

        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}