using crypto.Library.Api;
using crypto.Library.Models;
using crypto.Stores;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace crypto.ViewModels
{
    public class CurrencyDetailsViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public CurrencyModel Currency { get; }

        private List<MarketModel> _marketList;

        public List<MarketModel> MarketList
        {
            get { return _marketList; }
            private set 
            { 
                _marketList = value;
                OnPropertyChanged(nameof(MarketList));
            }
        }


        public CurrencyDetailsViewModel(NavigationStore navigationStore, CurrencyModel currency)
        {
            _navigationStore = navigationStore;
            Currency = currency;
            LoadedCommand = new DelegateCommand(LoadMarkets);
            GetBackCommand = new DelegateCommand(GoToCurrencyListView);
        }

        public ICommand GetBackCommand { get; set; }

        private void GoToCurrencyListView()
        {
            _navigationStore.CurrentViewModel = new CurrencyListViewModel(_navigationStore);
        }

        private async void LoadMarkets()
        {
            var currencyEndpoint = new CurrencyEndpoint();

            MarketList = await currencyEndpoint.GetMarketsByCurrencyId(Currency.id, 20, 0);
        }
    }
}
