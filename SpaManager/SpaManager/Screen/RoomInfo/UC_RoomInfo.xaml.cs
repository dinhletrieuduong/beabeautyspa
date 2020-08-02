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
using DTO;

namespace SpaManager.Screen.RoomInfo
{
    /// <summary>
    /// Interaction logic for UC_RoomInfo.xaml
    /// </summary>
    public partial class UC_RoomInfo : UserControl
    {
        public UC_RoomInfo()
        {
            InitializeComponent();

            List<Room_DTO> list = new List<Room_DTO>();

            list.Add(new Room_DTO { room_name = "Room 1", room_description = "Description", number_of_bed = "10", room_type = "1", room_check = false });
            list.Add(new Room_DTO { room_name = "Room 2", room_description = "Description", number_of_bed = "10", room_type = "1", room_check = false });

            list_itemroom.ItemsSource = list;
        }
        
    }
}
