﻿using System;
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

namespace SpaManager
{
    /// <summary>
    /// Interaction logic for LoginSpa.xaml
    /// </summary>
    public partial class LoginSpa : Window
    {
        public LoginSpa()
        {
            InitializeComponent();
        }

        public delegate void ClickLogin();
        public ClickLogin send;

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            if(send!=null)
            {
                send.Invoke();
                this.Close();
            }
        }
    }
}
