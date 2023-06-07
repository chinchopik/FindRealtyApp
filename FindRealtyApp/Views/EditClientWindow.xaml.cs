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
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditClientWindow : Window
    {
        ClientRepository clientRepository = new ClientRepository();
        private Client _client;
        public EditClientWindow(Client client)
        {
            InitializeComponent();
            FirstNameBox.Text = client.FirstName;
            LastNameBox.Text = client.LastName;
            PatronymicBox.Text = client.Patronymic;
            PhoneBox.Text = client.Phone;
            EmailBox.Text = client.Email;
            _client = client;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client
            {
                Id = _client.Id,
                FirstName = FirstNameBox.Text,
                LastName = LastNameBox.Text,
                Patronymic = PatronymicBox.Text,
                Phone = PhoneBox.Text,
                Email = EmailBox.Text
            };
            if (MessageBox.Show("Вы точно хотите изменить этот элемент?", "Всплывающее окно", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                try
                {
                    clientRepository.Edit(client);
                }
                finally
                {
                    MessageBox.Show("Данные успешно сохранены!", "Всплывающее окно", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    this.Close();
                }
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
