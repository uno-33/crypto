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

        public CurrencyDetailsViewModel(NavigationStore navigationStore, CurrencyModel currency)
        {
            _navigationStore = navigationStore;
            Currency = currency;
            GetBackCommand = new DelegateCommand(GoToCurrencyListView);
        }

        public ICommand GetBackCommand { get; set; }

        private void GoToCurrencyListView()
        {
            _navigationStore.CurrentViewModel = new CurrencyListViewModel(_navigationStore);
        }
    }
}
