using SpaManager.Menu;
using SpaManager.Screen.Dashboard;
using SpaManager.Screen.Login;
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
        public MainWindow()
        {
            InitializeComponent();

            Login login = new Login();

            login.send = gotoManageHome;
            login.Show();
            
            this.Hide();
            

            
        }

        public void gotoManageHome()
        {
            this.Show();

            DashBoard dash = new DashBoard();

            contain.Children.Clear();
            contain.Children.Add(dash);
        }


    }
}
