using FindRealtyApp.Models;
using FindRealtyApp.Repositories;
using FindRealtyApp.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FindRealtyApp.ViewModel
{
    class LoginViewModel : BaseModel
    {
        private string _password;
        private string _username;

        private IUserRepository userRepository;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }

        public ViewModelCommand Auth { get; private set; }
        public LoginViewModel()
        {
            userRepository = new UserRepository();
            Auth = new ViewModelCommand(Authenticate);
        }

        private void Authenticate()
        {
            if(Username!=null && Password != null)
            {
                try
                {
                    var isValidUser = userRepository.AuthenticateUser(Username, Password);
                    if (isValidUser)
                    {
                        userRepository.AddLoggingHistory(Username);
                        Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                        HomeWindow homeWindow = new HomeWindow();
                        Application.Current.MainWindow.Close();

                        homeWindow.Show();

                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
           
        }
    }
}
