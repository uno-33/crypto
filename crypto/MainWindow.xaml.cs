using crypto.Library.Api;
using crypto.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace crypto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICurrencyEndpoint _currencyEndpoint;
        public List<CurrencyModel> Currencies { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            _currencyEndpoint = new CurrencyEndpoint();
        }

        public async void OnLoaded(object sender, RoutedEventArgs e)
        {
            Currencies = await _currencyEndpoint.GetCurrencies(10, 0);
        }


    }
}
