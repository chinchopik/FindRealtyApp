using FindRealtyApp.Models;
using FindRealtyApp.Repositories;
using FindRealtyApp.Views;
using System;
using System.Collections.Generic;
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
            var isValidUser = userRepository.AuthenticateUser(Username, Password);
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                MenuWindow menuWindow = new MenuWindow();
                Application.Current.MainWindow.Close();
                menuWindow.Show();

            }
            else
                MessageBox.Show("freak-vonuchka");
        }
    }
}
