using FindRealtyApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FindRealtyApp.Views
{
    /// <summary>
    /// Логика взаимодействия для DealPage.xaml
    /// </summary>
    public partial class DealPage : Page
    {
        DealRepository dealRepository = new DealRepository();
        public DealPage()
        {
            InitializeComponent();
            DataGridView.ItemsSource = dealRepository.GetAllRealEstates();
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
