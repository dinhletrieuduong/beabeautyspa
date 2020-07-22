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

namespace SpaManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginSpa window;
        public MainWindow()
        {
            InitializeComponent();

            //LocalManger window = new LocalManger();
            //window.Show();

            window = new LoginSpa();

            window.send = gotoMangeAccount;
            window.Show();

            this.Hide();
        }

        private void gotoMangeAccount()
        {
            this.Show();
            ManageAccount window = new ManageAccount();

            contain.Children.Clear();
            contain.Children.Add(window);
            
        }
    }
}
