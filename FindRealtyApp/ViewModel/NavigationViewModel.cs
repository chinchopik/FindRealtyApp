using FindRealtyApp.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FindRealtyApp.ViewModel
{
    class NavigationViewModel : ICommand
    {
        private readonly NavigationStore _navigationStore;

        public NavigationViewModel(NavigationStore navigationStore)
        {
            Execute(navigationStore);
            _navigationStore = navigationStore;

        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new HomeViewModel(parameter as NavigationStore);
        }

        private void Navigate(NavigationStore navigationStore)
        {
            _navigationStore.CurrentViewModel = new HomeViewModel(navigationStore);
        }
    }
}
