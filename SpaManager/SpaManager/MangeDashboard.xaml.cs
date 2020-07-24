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
using SpaDTO;

namespace SpaManager
{
    /// <summary>
    /// Interaction logic for LocalMangerxaml.xaml
    /// </summary>
    public partial class MangeDashboard : UserControl
    {
        public MangeDashboard()
        {
            InitializeComponent();

            Menu window = new Menu();

            window.outletClick = ManageOutlet;
            window.accountClick = ManageAccount;
            window.roomClick = ManageRoomInfo;
            window.bedClick = ManageBed;
            window.serviceClick = ManageService;
            window.statisticClick = ManageStatistic;

            st_menu.Children.Clear();
            st_menu.Children.Add(window);

            
        }

        private void ManageRoomInfo()
        {
            BarRoomInfo barRoom = new BarRoomInfo();

            st_bar.Children.Clear();
            st_bar.Children.Add(barRoom);

            UC_ManageRoomInfo manageRoominfo = new UC_ManageRoomInfo();
            
            main_page.Children.Clear();
            main_page.Children.Add(manageRoominfo);
        }

        private void ManageAccount()
        {
            BarAccount barAccount = new BarAccount();

            st_bar.Children.Clear();
            st_bar.Children.Add(barAccount);

            UC_ManageAccount manageAccount = new UC_ManageAccount();

            main_page.Children.Clear();
            main_page.Children.Add(manageAccount);
        }

        private void ManageBed()
        {
            BarBed barbed = new BarBed();

            st_bar.Children.Clear();
            st_bar.Children.Add(barbed);

            UC_ManageBed manageBed = new UC_ManageBed();

            main_page.Children.Clear();
            main_page.Children.Add(manageBed);
        }

        private void ManageService()
        {
            BarService barService = new BarService();

            st_bar.Children.Clear();
            st_bar.Children.Add(barService);

            UC_ManageService manageService = new UC_ManageService();

            main_page.Children.Clear();
            main_page.Children.Add(manageService);
        }

        private void ManageOutlet()
        {
            BarOutlet barOutlet = new BarOutlet();

            st_bar.Children.Clear();
            st_bar.Children.Add(barOutlet);

            UC_ManageOutlet manageOutlet = new UC_ManageOutlet();

            main_page.Children.Clear();
            main_page.Children.Add(manageOutlet);
        }

        private void ManageStatistic()
        {
            BarStatistic barStatistic = new BarStatistic();

            st_bar.Children.Clear();
            st_bar.Children.Add(barStatistic);

            UC_ManageStatistic manageStatistic = new UC_ManageStatistic();

            main_page.Children.Clear();
            main_page.Children.Add(manageStatistic);

        }
    }
}
