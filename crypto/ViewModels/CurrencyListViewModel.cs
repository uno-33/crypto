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

        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set 
            { 
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                (SearchCommand as DelegateCommand).RaiseCanExecuteChanged();
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
            SearchCommand = new DelegateCommand(SearchCurrency, (() => SearchText != null && SearchText != String.Empty));
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

        private async void SearchCurrency()
        {
            var currencyEndpoint = new CurrencyEndpoint();

            var result = await currencyEndpoint.SearchCurrency(SearchText);

            if(result != null)
            {
                var newList = new List<CurrencyModel>();
                newList.Add(result);

                CurrencyList = newList;
            }
            else
            {
                SearchText = String.Empty;
            }
        }
    }
}
