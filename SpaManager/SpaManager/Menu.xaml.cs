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

namespace SpaManager
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
        }

        public delegate void MenuClick();

        public MenuClick outletClick;
        public MenuClick accountClick;
        public MenuClick roomClick;
        public MenuClick bedClick;
        public MenuClick serviceClick;
        public MenuClick statisticClick;
        private void menu_room_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(roomClick!=null)
            {
                roomClick.Invoke();
            }
        }

        private void menu_outlet_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (outletClick != null)
            {
                outletClick.Invoke();
            }
        }

        private void menu_account_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(accountClick!=null)
            {
                accountClick.Invoke();
            }
        }

        private void menu_bed_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(bedClick!=null)
            {
                bedClick.Invoke();
            }
        }

        private void menu_service_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(serviceClick!=null)
            {
                serviceClick.Invoke();
            }
        }

        private void menu_statistic_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(statisticClick!=null)
            {
                statisticClick.Invoke();
            }
        }
    }
}
