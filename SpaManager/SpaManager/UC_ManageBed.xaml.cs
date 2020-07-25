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
    /// Interaction logic for UC_ManageRoomInfo.xaml
    /// </summary>
    public partial class UC_ManageBed : UserControl
    {
        public UC_ManageBed()
        {
            InitializeComponent();

            List<RoomInfo> list = new List<RoomInfo>();

            list.Add(new RoomInfo { room_name = "Bed 1", room_service = "Massage", room_description = "Description", room_type = "1", room_check = false });
            list.Add(new RoomInfo { room_name = "Bed 1", room_service = "Massage", room_description = "Description", room_type = "1", room_check = false });

            list_itemroom.ItemsSource = list;
        }

        private void btn_checkitem_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
