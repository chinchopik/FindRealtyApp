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
using System.Windows.Shapes;

namespace FindRealtyApp.Views
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
        }

        private void ButtonClients_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ClientPage();
        }

        private void RealEstatesPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new RealEstatePage();
        }

        private void ButtonDeals_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new DealPage();
        }

        private void ButtonLogOut_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            Application.Current.MainWindow = loginWindow;
            loginWindow.Show();
            this.Close();
        }

        private void ButtonStatistics_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new StatisticsPage();
        }
    }
}
