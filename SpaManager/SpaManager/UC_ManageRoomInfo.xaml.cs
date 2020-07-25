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
using SpaDTO;

namespace SpaManager
{
    /// <summary>
    /// Interaction logic for UC_ManageOutlet.xaml
    /// </summary>
    public partial class UC_ManageRoomInfo : UserControl
    {
        public UC_ManageRoomInfo()
        {
            InitializeComponent();

            List<testOutlet> list = new List<testOutlet>();

            list.Add(new testOutlet { outlet_name = "Room 1", outlet_description = "Description", outlet_bed ="10",outlet_type="1",outlet_check=false });
            list.Add(new testOutlet { outlet_name = "Room 2", outlet_description = "Description", outlet_bed = "10", outlet_type = "1", outlet_check = false });

            list_itemoutlet.ItemsSource = list;
        }

        private void btn_checkitem_Checked(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
