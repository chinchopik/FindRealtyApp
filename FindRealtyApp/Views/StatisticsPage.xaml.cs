using FindRealtyApp.Repositories;
using LiveCharts;
using LiveCharts.Wpf;
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
    /// Логика взаимодействия для StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : Page
    {
        RealEstateRepository realEstateRepository = new RealEstateRepository();
        public StatisticsPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var infoApartments = realEstateRepository.GetApartments().Count();
            var infoHouses = realEstateRepository.GetHouses().Count();
            var infoLands = realEstateRepository.GetLands().Count();

            var pieSeries = new SeriesCollection();
            pieSeries.Add(new PieSeries { Title = "Квартиры", Values = new ChartValues<int> { infoApartments }, DataLabels = true });
            pieSeries.Add(new PieSeries { Title = "Дома", Values = new ChartValues<int> { infoHouses }, DataLabels = true });
            pieSeries.Add(new PieSeries { Title = "Земельных участков", Values = new ChartValues<int> { infoLands }, DataLabels = true });

            pieChart.Series = pieSeries;
        }
    }
}
