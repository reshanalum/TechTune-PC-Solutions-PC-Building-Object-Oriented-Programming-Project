using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FINALPROJECT_OOP_ALUM.Models;
using FINALPROJECT_OOP_ALUM.Views;
using FINALPROJECT_OOP_ALUM.Commands;
using System.Windows;
using System.Runtime.CompilerServices;

namespace FINALPROJECT_OOP_ALUM.ViewModels
{
    public class LoginViewModel : NotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand LoginCommand { get; set; }
        private string _username;
        private string _password;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login, CanLogin);
        }
        private void Login(object parameter)
        {

            if (Username == "Reshan" && Password == "123")
            {
                DashboardWindow dashboardWindow = new DashboardWindow();
                dashboardWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                dashboardWindow.Show();
            }
            else
            {
                MessageBox.Show("Login Unsuccessful\nIncorrect Input of either Username or Password.", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private bool CanLogin(object parameter)
        {
            return true;
        }

    }
}

