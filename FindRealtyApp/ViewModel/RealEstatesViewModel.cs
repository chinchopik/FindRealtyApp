using FindRealtyApp.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FindRealtyApp.ViewModel
{
    class RealEstatesViewModel : BaseModel
    {
        public ICommand command;
        public RealEstatesViewModel(NavigationStore navigationStore)
        {
            command = new NavigationViewModel(navigationStore);
        }
    }
}
