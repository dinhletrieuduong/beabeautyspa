using SpaManager.ApiConnection;
using SpaManager.Bar;
using SpaManager.Menu;
using SpaManager.Screen.Account;
using SpaManager.Screen.Appointment;
using SpaManager.Screen.Bed;
using SpaManager.Screen.Outlet;
using SpaManager.Screen.RoomInfo;
using SpaManager.Screen.Service;
using SpaManager.Screen.ServiceActive;
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
        public string token = "";

        
        public DashBoard()
        {
            InitializeComponent();

            

            MenuBar menu = new MenuBar();

            menu.AccountClick = ManageAccount;
            
            menu.ServiceClick = ManageService;
            menu.OutletClick = ManageOutlet;
            menu.StatisticClick = ManageStatistic;
            menu.AppointmentClick = ManageAppointment;

            st_menu.Children.Clear();
            st_menu.Children.Add(menu);

            //ManageBed("1");

        }

        private void ManageAccount()
        {
            // set_TopBar("Account");

            TopBar topbar = new TopBar("Account");

            st_bar.Children.Clear();
            st_bar.Children.Add(topbar);

            UC_Account account = new UC_Account();

            topbar.search = account.Search_Account;
            topbar.send = account.Restore;

            account.send = ManageAccount;
            set_Mainpage(account);
        }

        private void ManageBed(string room_id)
        {
            //set_TopBar("Bed");

            TopBar topbar = new TopBar("Bed");

            st_bar.Children.Clear();
            st_bar.Children.Add(topbar);

            UC_Bed bed = new UC_Bed(room_id);
            bed.send = ManageBed;

            topbar.search = bed.Search_Bed;
            topbar.send = bed.Restore;

            set_Mainpage(bed);
        }
        private void ManageService()
        {
            //set_TopBar("Service");

            TopBar topbar = new TopBar("Service");

            st_bar.Children.Clear();
            st_bar.Children.Add(topbar);

            UC_Service service = new UC_Service();

            topbar.search = service.Search_Service;
            topbar.send = service.Restore;

            service.send = ManageService;

            set_Mainpage(service);
        }
        
        private void ManageOutlet()
        {
            //set_TopBar("Outlet");

            TopBar topbar = new TopBar("Outlet");

            st_bar.Children.Clear();
            st_bar.Children.Add(topbar);


            UC_Outlet outlet = new UC_Outlet();

            topbar.search = outlet.Search_Outlet;
            topbar.send = outlet.Restore;

            outlet.send = ManageOutlet;
            outlet.room = ManageRoom;
            outlet.ViewService = ManageServiceActive;

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

        private void ManageRoom(string outlet_id)
        {
            //set_TopBar("Room");

            TopBar topbar = new TopBar("Room");

            st_bar.Children.Clear();
            st_bar.Children.Add(topbar);

            UC_RoomInfo room = new UC_RoomInfo(outlet_id);
            room.manage_bed = ManageBed;
            room.send = ManageRoom;

            topbar.search = room.Search_Room;
            topbar.send = room.Restore;

            set_Mainpage(room);
        }

        private void ManageServiceActive()
        {
            set_TopBar("Service");

            UC_ServiceActive service = new UC_ServiceActive();
            
            set_Mainpage(service);

        }

        private void ManageAppointment()
        {
            set_TopBar("Appointment");

            UC_Appointment appt = new UC_Appointment();

            set_Mainpage(appt);
        }
    }
}
