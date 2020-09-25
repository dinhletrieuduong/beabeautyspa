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

namespace SpaManager.Menu
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class MenuBar : UserControl
    {
        public MenuBar()
        {
            InitializeComponent();
        }

        public delegate void ManageMenu();

        public ManageMenu AccountClick;
        public ManageMenu ServiceClick;
        public ManageMenu OutletClick;
        public ManageMenu StatisticClick;
        public ManageMenu AppointmentClick;
        private void menu_account_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(AccountClick!=null)
            {
                AccountClick.Invoke();
            }
        }

        private void menu_service_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(ServiceClick!=null)
            {
                ServiceClick.Invoke();
            }
        }

       

        private void menu_outlet_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(OutletClick!=null)
            {
                OutletClick.Invoke();
            }
        }

        private void menu_statistic_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(StatisticClick!=null)
            {
                StatisticClick.Invoke();
            }
        }

        private void menu_appointment_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(AppointmentClick != null)
            {
                AppointmentClick.Invoke();
            }
        }
    }
}
