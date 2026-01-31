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
using FINALPROJECT_OOP_ALUM.ViewModels;
using FINALPROJECT_OOP_ALUM.Models;

namespace FINALPROJECT_OOP_ALUM.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            //connects the View Model to its corresponding View
            InitializeComponent();
            LoginViewModel loginViewModel = new LoginViewModel();
            this.DataContext = loginViewModel;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {


        }

        private void Pass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is LoginViewModel viewModel)
            {
                var passwordBox = sender as PasswordBox;
                viewModel.Password = passwordBox.Password;
            }
        }
    }
}
