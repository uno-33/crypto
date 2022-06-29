using crypto.Library.Api;
using crypto.Library.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace crypto.ViewModels
{
    public class CurrencyListViewModel : ViewModelBase
    {
        private List<CurrencyModel> _currencyList;
        public CurrencyModel SelectedCurrency { get; set; }

        public List<CurrencyModel> CurrencyList
        {
            get { return _currencyList; }
            private set 
            { 
                _currencyList = value; 
                OnPropertyChanged(nameof(CurrencyList));
            }
        }

        public ICommand SearchCommand { get; }
        public ICommand DetailsCommand { get; set; }

        public CurrencyListViewModel()
        {
            LoadedCommand = new DelegateCommand(LoadData);
        }

        private async void LoadData()
        {
            var currencyEndpoint = new CurrencyEndpoint();

            CurrencyList = await currencyEndpoint.GetCurrencies(10, 0);
        }


    }
}
