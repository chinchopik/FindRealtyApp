using FindRealtyApp.Models;
using FindRealtyApp.Repositories;
using FindRealtyApp.Stores;
using System;
using System.Collections;
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
    /// Логика взаимодействия для RealEstatePage.xaml
    /// </summary>
    public partial class RealEstatePage : Page
    {
        RealEstateRepository realEstateRepository = new RealEstateRepository();

        private readonly Dictionary<string, RealEstateType> map = new Dictionary<string, RealEstateType>
        {
            ["Дом"] = RealEstateType.House,
            ["Земля"] = RealEstateType.Land,
            ["Квартира"] = RealEstateType.Apartments
        };

        public RealEstatePage()
        {
            InitializeComponent();
            DataGridView.ItemsSource = realEstateRepository.GetAllRealEstates();

        
            RealEstatesTypes.Items.Add("По умолчанию");
            RealEstatesTypes.Items.Add("Дом");
            RealEstatesTypes.Items.Add("Земля");
            RealEstatesTypes.Items.Add("Квартира");
            RealEstatesTypes.SelectedItem = "По умолчанию";
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if(DataGridView.SelectedItem != null)
            {
                EditRealEstateWindow editRealEstateWindow = new EditRealEstateWindow(map[(string)(RealEstatesTypes.SelectedItem)], DataGridView.SelectedItem as RealEstate);
                editRealEstateWindow.ShowDialog();
                DataGridView.ItemsSource = realEstateRepository.GetAllRealEstates();
                RealEstatesTypes.SelectedItem = "По умолчанию";
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            /*MessageBox.Show($"{DataGridView.SelectedCells[0].Column.GetCellContent(DataGridView.SelectedCells[0].Item).DataContext.ToString()}");*/
            if (MessageBox.Show("Вы точно хотите удалить этот элемент?", "Всплывающее окно", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                try
                {
                    switch (RealEstatesTypes.SelectedItem)
                    {
                        case "Дом":
                            realEstateRepository.Remove((DataGridView.SelectedItem as House).Id);
                            break;
                        case "Земля":
                            realEstateRepository.Remove((DataGridView.SelectedItem as Land).Id);
                            break;
                        case "Квартира":
                            realEstateRepository.Remove((DataGridView.SelectedItem as Apartment).Id);
                            break;
                        default:
                            realEstateRepository.Remove((DataGridView.SelectedItem as RealEstate).Id);
                            break;
                    }                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}");
                }
                finally
                {
                    MessageBox.Show("Данные успешно удалены!", "Всплывающее окно", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    DataGridView.ItemsSource = realEstateRepository.GetAllRealEstates();
                    RealEstatesTypes.SelectedItem = "По умолчанию";
                }
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (RealEstatesTypes.SelectedItem == "По умолчанию")
            {
                MessageBox.Show("Сначала выберите тип объекта недвижимости", "Всплывающее окно", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            AddRealEstateWindow addRealEstateWindow = new AddRealEstateWindow(map[(string)(RealEstatesTypes.SelectedItem)]);
            addRealEstateWindow.ShowDialog();
            DataGridView.ItemsSource = realEstateRepository.GetAllRealEstates();
            RealEstatesTypes.SelectedItem = "По умолчанию";
        }

        private void RealEstatesTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RealEstatesTypes.SelectedItem == "Дом") DataGridView.ItemsSource = realEstateRepository.GetHouses();
            if (RealEstatesTypes.SelectedItem == "Земля") DataGridView.ItemsSource = realEstateRepository.GetLands();
            if (RealEstatesTypes.SelectedItem == "Квартира") DataGridView.ItemsSource = realEstateRepository.GetApartments();
            if (RealEstatesTypes.SelectedItem == "По умолчанию") DataGridView.ItemsSource = realEstateRepository.GetAllRealEstates();

        }
    }
}
