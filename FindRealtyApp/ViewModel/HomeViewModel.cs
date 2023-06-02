using FindRealtyApp.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRealtyApp.ViewModel
{
    class HomeViewModel : BaseModel
    {
        private readonly NavigationStore _navigationStore;
        public BaseModel CurrentViewModel => _navigationStore.CurrentViewModel;
        
        public HomeViewModel(NavigationStore navigationStore)
        {
           
            _navigationStore = navigationStore;
        }
    }
}
