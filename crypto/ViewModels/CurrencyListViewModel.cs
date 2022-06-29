using crypto.Library.Api;
using crypto.Library.Models;
using crypto.Stores;
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
        private readonly NavigationStore _navigationStore;


        private CurrencyModel _selectedCurrency;

        public CurrencyModel SelectedCurrency
        {
            get { return _selectedCurrency; }
            set 
            { 
                _selectedCurrency = value;
                OnPropertyChanged(nameof(SelectedCurrency));
                (DetailsCommand as DelegateCommand).RaiseCanExecuteChanged();
            }
        }


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
        public ICommand DetailsCommand { get; }
        public ICommand RefreshCommand { get; }

        public CurrencyListViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            LoadedCommand = new DelegateCommand(LoadData);
            RefreshCommand = new DelegateCommand(LoadData);
            DetailsCommand = new DelegateCommand(LoadCurrencyDetailsView, (() => SelectedCurrency != null));
        }

        private async void LoadData()
        {
            var currencyEndpoint = new CurrencyEndpoint();

            CurrencyList = await currencyEndpoint.GetCurrencies(10, 0);
        }

        private void LoadCurrencyDetailsView()
        {
            _navigationStore.CurrentViewModel = new CurrencyDetailsViewModel(_navigationStore, SelectedCurrency);
        }
    }
}
