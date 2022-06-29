using System;
using System.Collections.Generic;
using System.Text;

namespace crypto.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }

        public MainViewModel()
        {
            CurrentViewModel = new CurrencyListViewModel();
        }
    }
}
