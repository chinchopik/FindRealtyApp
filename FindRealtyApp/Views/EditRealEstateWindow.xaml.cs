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
    /// Логика взаимодействия для EditRealEstateWindow.xaml
    /// </summary>
    public partial class EditRealEstateWindow : Window
    {
        private RealEstateRepository realEstateRepository = new RealEstateRepository();
        private RealEstate _realEstate;
        RealEstateType currentType;
        public EditRealEstateWindow(RealEstateType type, RealEstate realEstate)
        {
            InitializeComponent();

            switch (type)
            {
                case RealEstateType.Land:
                    FloorsBox.IsEnabled = false;
                    RoomsBox.IsEnabled = false;
                    Land land = realEstate as Land;
                    AddressBox.Text = land.Address;
                    AreaBox.Text = land.TotalArea.ToString();
                    _realEstate = land;
                    currentType = type;
                    break;

                case RealEstateType.House:
                    RoomsBox.IsEnabled = false;
                    House house = realEstate as House;
                    AddressBox.Text = house.Address;
                    AreaBox.Text = house.TotalArea.ToString();
                    FloorsBox.Text = house.TotalFloors.ToString();
                    _realEstate = house;
                    currentType = type;
                    break;
        
                case RealEstateType.Apartments:
                    Apartment apartment = realEstate as Apartment;
                    AddressBox.Text = apartment.Address;
                    AreaBox.Text = apartment.TotalArea.ToString();
                    FloorsBox.Text = apartment.TotalFloors.ToString();
                    RoomsBox.Text = apartment.NumberOfRooms.ToString();
                    _realEstate = apartment;
                    currentType = type;
                    break;
                default:
                    break;
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (currentType == RealEstateType.Land)
            {
                Land land = _realEstate as Land;
                land.Address = AddressBox.Text;
                land.TotalArea = Convert.ToDouble(AreaBox.Text);
                realEstateRepository.EditLand(land);
            }
            if (currentType == RealEstateType.House)
            {
                House house = _realEstate as House;
                house.Address = AddressBox.Text;
                house.TotalArea = Convert.ToDouble(AreaBox.Text);
                house.TotalFloors = Convert.ToInt32(FloorsBox.Text);
                realEstateRepository.EditHouse(house);
            }
            if (currentType == RealEstateType.Apartments)
            {
                Apartment apartment = _realEstate as Apartment;
                apartment.Address = AddressBox.Text;
                apartment.TotalArea = Convert.ToDouble(AreaBox.Text);
                apartment.TotalFloors = Convert.ToInt32(FloorsBox.Text);
                apartment.NumberOfRooms = Convert.ToInt32(RoomsBox.Text);
                realEstateRepository.EditApartment(apartment);
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
