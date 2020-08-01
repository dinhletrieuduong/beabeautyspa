using SpaManager.ApiConnection;
using SpaManager.Model;
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

namespace SpaManager.Screen.Login
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        public delegate void LoginClick();
        public LoginClick send;

       
        private async void btn_login_Click(object sender, RoutedEventArgs e)
        {
            LoginRequest loginRequest = new LoginRequest
            {
                username = txt_username.Text,
                password = txt_password.Password
            };

            LoginResponse loginResponse = await RestAPI.PostLogin(loginRequest);

            if (loginResponse.token != null)
            {
                if (send != null)
                {
                    send.Invoke();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Login Fail");
            }
        }
    }
}
