using FindRealtyApp.Models;
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
using System.Windows.Shapes;

namespace FindRealtyApp.Views
{
    /// <summary>
    /// Логика взаимодействия для AddDealWindow.xaml
    /// </summary>
    public partial class AddDealWindow : Window
    {
        RealEstateRepository realEstateRepository = new RealEstateRepository();
        ClientRepository clientRepository = new ClientRepository();
        DealRepository dealRepository = new DealRepository();
        public AddDealWindow()
        {
            InitializeComponent();
            AddressBox.ItemsSource = realEstateRepository.GetAllRealEstates().Select(p=>p.Address).Except(dealRepository.GetAllRealEstates().Select(p => p.Address)); 
            ClientBox.ItemsSource = clientRepository.GetAllClients().Select(p=>$"{p.LastName} {p.FirstName} {p.Patronymic}").ToList();
            AgentBox.ItemsSource = clientRepository.GetAllAgents().Select(p => $"{p.LastName} {p.FirstName} {p.Patronymic}").ToList();
      
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddressBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PriceBox.Text = realEstateRepository.GetAllRealEstates().Where(p => p.Address == AddressBox.SelectedItem.ToString()).Select(p => p.Price).ToList().ElementAt(0).ToString();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int clientId = clientRepository.GetAllClients().Where(p=> $"{p.LastName} {p.FirstName} {p.Patronymic}" == ClientBox.SelectedItem.ToString()).Select(p=>p.Id).ToList().ElementAt(0);
                int realEstateId = realEstateRepository.GetAllRealEstates().Where(p=> p.Address == AddressBox.SelectedItem.ToString()).Select(p=>p.Id).FirstOrDefault();
                int agentId = clientRepository.GetAllAgents().Where(p => $"{p.LastName} {p.FirstName} {p.Patronymic}" == AgentBox.SelectedItem.ToString()).Select(p => p.Id).ToList().ElementAt(0);
                DateTime date = DateBox.SelectedDate.Value;


                List<Deal> deals = new List<Deal>()
                {
                    new Deal {Id = 0, Address = realEstateId.ToString(), Client = clientId.ToString(), Agent = agentId.ToString(), Date = date }
                };
                dealRepository.AddDeal(deals);
                MessageBox.Show("Данные успешно сохранены!", "Всплывающее окно", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
            finally
            {
                this.Close();
            }
        }
    }
}
