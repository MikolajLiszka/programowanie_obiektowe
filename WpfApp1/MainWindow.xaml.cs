﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WpfApp1
{
    record Rate(string Code, double Bid, double Ask);
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, Rate> Rates = new Dictionary<string, Rate>();

        private void DownloadData()
        {
            //pobranie danych
            WebClient client = new WebClient();
            client.Headers.Add("Content-Type", "application/xml");
            string xml = client.DownloadString("");
            XDocument doc = XDocument.Parse(xml);
            //zamienic xml na słownik rekordow Rate
        }

        private void DownloadJsonData()
        {
            WebClient client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
            string json = client.DownloadString("http://api.nbp.pl/api/exchangerate/")
        }
        public MainWindow()
        {
            InitializeComponent();
            DownloadData();
            InputCurrencyCode.Items.Add("USD");
            InputCurrencyCode.Items.Add("PLN");
            InputCurrencyCode.Items.Add("EUR");
            OutputCurrencyCode.Items.Add("USD");
            OutputCurrencyCode.Items.Add("PLN");
            OutputCurrencyCode.Items.Add("EUR");
            InputCurrencyCode.SelectedIndex = 0;
            OutputCurrencyCode.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //kod przeliczania walut
            string inputCode = InputCurrencyCode.Text;
            string resultCode = OutputCurrencyCode.Text;
            decimal amount = decimal.Parse(InputValue.Text);
            //pobrac Rate dla inputCode i resultCode
            //obliczyc na podstawie pola Ask lub Bid kwotę po przeliczeniu
            //wyswietlic kwote w polu ResultValue
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {    
            e.Handled = !decimal.TryParse(e.Text, out decimal value);

        }

        public class RateTable 
        {
            public string table { get; set; }

            public string no { get; set; }


        }
    }
}
