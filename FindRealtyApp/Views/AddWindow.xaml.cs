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
    /// Логика взаимодействия для AddEditWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        ClientRepository clientRepositoty = new ClientRepository();
        public AddWindow()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client client = new Client
                {
                    FirstName = FirstNameBox.Text,
                    LastName = LastNameBox.Text,
                    Patronymic = PatronymicBox.Text,
                    Phone = PhoneBox.Text,
                    Email = EmailBox.Text
                };
                clientRepositoty.Add(client);
            }
            finally
            {
                MessageBox.Show("Данные успешно сохранены!","Всплывающее окно", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                this.Close();
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
