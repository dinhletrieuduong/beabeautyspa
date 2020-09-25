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
using DTO;
using SpaManager.ApiConnection;
using SpaManager.Model;

namespace SpaManager.Screen.Account
{
    /// <summary>
    /// Interaction logic for UC_Account.xaml
    /// </summary>
    public partial class UC_Account : UserControl
    {
        public UC_Account()
        {
            InitializeComponent();

            _Load();
        }

        public delegate void Reload();
        public Reload send;

        List<User_DTO> listaccount = new List<User_DTO>();
        private async void _Load()
        {
            List<User_DTO> listuser = new List<User_DTO>();

            listuser = await RestAPI.GetAccount();
            listaccount = listuser;

            foreach(User_DTO temp in listuser)
            {
               if(temp.is_block)
                {
                    temp.block = "Check";
                }
                else
                {
                    temp.block = "Block";
                }
            }

            list_user.ItemsSource = listuser;
            progress_bar.Visibility = Visibility.Collapsed;
        }
        private async void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            progress_bar.Visibility = Visibility.Visible;

            Button button = sender as Button;

            User_DTO user = button.DataContext as User_DTO;

            bool result = await RestAPI.PostDeleteAccount(user.account_id.ToString());

            if (send != null)
                send.Invoke();
            progress_bar.Visibility = Visibility.Collapsed;
            if (result)
            {
                MessageBox.Show("Delete Successful");
            }
            else
                MessageBox.Show("Delete Fail");
        }

        private async void btn_block_Click(object sender, RoutedEventArgs e)
        {
            progress_bar.Visibility = Visibility.Visible;

            Button button = sender as Button;

            User_DTO user = button.DataContext as User_DTO;

            AccountBlock temp = new AccountBlock();

            temp.account_id = user.account_id;

            bool result = false;

            if (user.is_block)
                result = await RestAPI.PostBlock(temp, "unlock");
            else
                result = await RestAPI.PostBlock(temp, "lock");

            if (send != null)
                send.Invoke();

            progress_bar.Visibility = Visibility.Collapsed;
            if (result)
            {
                MessageBox.Show("Successful");
            }
            else
                MessageBox.Show("Fail");
        }

        public void Search_Account(string account_name)
        {
            if (account_name != "")
            {
                List<User_DTO> list_temp = new List<User_DTO>();

                foreach (User_DTO temp in listaccount)
                {
                    if (temp.username.ToLower() == account_name.ToLower())
                    {
                        list_temp.Add(temp);
                    }
                }

                list_user.ItemsSource = list_temp;
            }
        }

        private void btn_active_Checked(object sender, RoutedEventArgs e)
        {
            btn_blocked.IsChecked = false;

            List<User_DTO> list_temp = new List<User_DTO>();

            if(btn_active.IsChecked == true)
            {
                foreach(User_DTO temp in listaccount)
                {
                    if(temp.is_block)
                    {
                        list_temp.Add(temp);
                    }
                }

               
                list_user.ItemsSource = list_temp;
            }
           
        }

        private void btn_blocked_Checked(object sender, RoutedEventArgs e)
        {
            btn_active.IsChecked = false;

            List<User_DTO> list_temp = new List<User_DTO>();

            if (btn_blocked.IsChecked == true)
            {
                foreach (User_DTO temp in listaccount)
                {
                    if (!temp.is_block)
                    {
                        list_temp.Add(temp);
                    }
                }

              
                list_user.ItemsSource = list_temp;
            }
           
        }

        private void btn_blocked_Unchecked(object sender, RoutedEventArgs e)
        {
          
            list_user.ItemsSource = listaccount;
        }

        private void btn_active_Unchecked(object sender, RoutedEventArgs e)
        {
            
            list_user.ItemsSource = listaccount;
        }

        public void Restore()
        {
            
            list_user.ItemsSource = listaccount;
        }
    }
}
