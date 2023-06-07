using FindRealtyApp.Models;
using FindRealtyApp.Repositories;
using FindRealtyApp.Stores;
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
    /// Логика взаимодействия для AddRealEstateWindow.xaml
    /// </summary>
    public partial class AddRealEstateWindow : Window
    {
        RealEstateRepository realEstateRepository = new RealEstateRepository();
        private RealEstateType type;
        public AddRealEstateWindow(RealEstateType type)
        {
            InitializeComponent();
            this.type = type;
            if (type == RealEstateType.Land)
            {
                FloorsBox.IsEnabled = false;
                RoomsBox.IsEnabled = false;
            }
            else if (type == RealEstateType.House)
            {
                RoomsBox.IsEnabled = false;
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(type == RealEstateType.Land)
                {
                    Land land = new Land();
                    land.Address = AddressBox.Text;
                    land.TotalArea = Convert.ToDouble(AreaBox.Text);
                    realEstateRepository.AddLand(land);
                }
                else if (type == RealEstateType.House)
                {
                    House house = new House();
                    house.Address = AddressBox.Text;
                    house.TotalArea = Convert.ToDouble(AreaBox.Text);
                    house.TotalFloors = Convert.ToInt32(FloorsBox.Text);
                    realEstateRepository.AddHouse(house);
                }
                else
                {
                    Apartment apartment = new Apartment();
                    apartment.Address = AddressBox.Text;
                    apartment.TotalArea = Convert.ToDouble(AreaBox.Text);
                    apartment.TotalFloors = Convert.ToInt32(FloorsBox.Text);
                    apartment.NumberOfRooms = Convert.ToInt32(RoomsBox.Text);
                    realEstateRepository.AddApartment(apartment);
                }
            }
            finally
            {
                MessageBox.Show("Данные успешно сохранены!", "Всплывающее окно", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                this.Close();
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
