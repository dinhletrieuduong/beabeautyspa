using SpaManager.Bar;
using SpaManager.Menu;
using SpaManager.Screen.Account;
using SpaManager.Screen.Bed;
using SpaManager.Screen.Outlet;
using SpaManager.Screen.RoomInfo;
using SpaManager.Screen.Service;
using SpaManager.Screen.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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

namespace SpaManager.Screen.Dashboard
{
    /// <summary>
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : UserControl
    {
        public DashBoard()
        {
            InitializeComponent();

            MenuBar menu = new MenuBar();

            menu.AccountClick = ManageAccount;
            menu.BedClick = ManageBed;
            menu.ServiceClick = ManageService;
            menu.RoomClick = ManageRoom;
            menu.OutletClick = ManageOutlet;
            menu.StatisticClick = ManageStatistic;

            st_menu.Children.Clear();
            st_menu.Children.Add(menu);

            

        }

        private void ManageAccount()
        {
            set_TopBar("Account");

            UC_Account account = new UC_Account();

            set_Mainpage(account);
        }

        private void ManageBed()
        {
            set_TopBar("Bed");

            UC_Bed bed = new UC_Bed();

            set_Mainpage(bed);
        }
        private void ManageService()
        {
            set_TopBar("Service");

            UC_Service service = new UC_Service();

            set_Mainpage(service);
        }
        private void ManageRoom()
        {
            set_TopBar("Room");

            UC_RoomInfo room = new UC_RoomInfo();

            set_Mainpage(room);
        }
        private void ManageOutlet()
        {
            set_TopBar("Outlet");

            UC_Outlet outlet = new UC_Outlet();

            set_Mainpage(outlet);
        }

        private void ManageStatistic()
        {
            set_TopBar("Statistic");

            UC_Statistic statistic = new UC_Statistic();

            set_Mainpage(statistic);
        }
        private void set_Mainpage(UserControl uc)
        {
            main_page.Children.Clear();
            main_page.Children.Add(uc);
        }
        private void set_TopBar(string title)
        {
            TopBar topbar = new TopBar(title);

            st_bar.Children.Clear();
            st_bar.Children.Add(topbar);
        }
    }
}
