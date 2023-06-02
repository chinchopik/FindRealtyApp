
using FindRealtyApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FindRealtyApp.ViewModel
{
    class HomeViewModel : BaseModel
    {

        public Page CurrentPage
        {
            get => new RealEstatesPage();
        }
        public HomeViewModel()
        {

        }
    }
}
