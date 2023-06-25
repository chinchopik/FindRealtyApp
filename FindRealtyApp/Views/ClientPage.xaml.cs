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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FindRealtyApp.Views
{
    /// <summary>
    /// Логика взаимодействия для RealEstatesPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        private ClientRepository _clientRepository = new ClientRepository();
        public ClientPage()
        {
            InitializeComponent();

            DataGridView.ItemsSource = _clientRepository.GetAllClients();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow addEditWindow = new AddClientWindow();
            addEditWindow.ShowDialog();
            DataGridView.ItemsSource = _clientRepository.GetAllClients();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {         
            if (MessageBox.Show("Вы точно хотите удалить этот элемент?", "Всплывающее окно", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                try
                {
                    _clientRepository.Remove(DataGridView.SelectedItem as Client);
                    MessageBox.Show("Данные успешно удалены!", "Всплывающее окно", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                   DataGridView.ItemsSource = _clientRepository.GetAllClients();
                }
            }
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridView.SelectedItem != null)
            {
                EditClientWindow EditWindow = new EditClientWindow(DataGridView.SelectedItem as Client);
                EditWindow.ShowDialog();
                DataGridView.ItemsSource = _clientRepository.GetAllClients();
            }
        }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGridView.ItemsSource = _clientRepository.GetAllClients().Where(p => p.LastName.ToLower().Contains(SearchBar.Text.ToLower())
                    || p.FirstName.ToLower().Contains(SearchBar.Text.ToLower())
                    || p.Patronymic.ToLower().Contains(SearchBar.Text.ToLower())
                    || p.Phone.ToLower().Contains(SearchBar.Text.ToLower())
                    || p.Email.ToLower().Contains(SearchBar.Text.ToLower())).ToList();
        }
    }
}
