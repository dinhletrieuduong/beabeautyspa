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
using SpaManager.ApiConnection;
using SpaManager.Form.CreateRoom;
using SpaManager.Model;

namespace SpaManager.Screen.RoomInfo
{
    /// <summary>
    /// Interaction logic for UC_RoomInfo.xaml
    /// </summary>
    public partial class UC_RoomInfo : UserControl
    {
        string outletid = string.Empty;
        public UC_RoomInfo(string outlet_id)
        {
            InitializeComponent();

            _Load(outlet_id);
        }

        public delegate void ReLoad(string outlet_id);
        public ReLoad send;

        public delegate void ManageDash(string str);
        public ManageDash manage_bed;

        List<Room_DTO> list_room_current = new List<Room_DTO>();
        private async void _Load(string outlet_id)
        {
            outletid = outlet_id;

            List<Room_DTO> list = new List<Room_DTO>();

            list = await RestAPI.GetRoom(outlet_id);

            list_room_current = list;
            progress_bar.Visibility = Visibility.Collapsed;
           
            list_itemroom.ItemsSource = list;

        }

        private async void btn_create_Click(object sender, RoutedEventArgs e)
        {
            FormCreateRoom form = new FormCreateRoom();

            form.ShowDialog();

            if(form.status)
            {
                RoomRequest request = new RoomRequest();

                request.outlet_id = Int32.Parse(outletid);
                request.room_name = form.Get_Roomname();
                request.max_beds = form.Get_maxbed();
                request.r_type = form.Get_RoomTypeID();

                progress_bar.Visibility = Visibility.Visible;
                bool result = await RestAPI.CreateRoom(request);
                progress_bar.Visibility = Visibility.Collapsed;

                if (result)
                {
                    if(send!=null)
                    {
                        send.Invoke(outletid);
                    }

                    MessageBox.Show("Create Room Successful");
                }
                else
                {
                    MessageBox.Show("Create Room Fail");
                }
            }
            
        }

        private async void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            progress_bar.Visibility = Visibility.Visible;

            List<Room_DTO> listroom = list_itemroom.ItemsSource as List<Room_DTO>;

            foreach(Room_DTO temp in listroom)
            {
                if(temp.room_check)
                {
                    bool result = await RestAPI.PostDeleteRoom(temp.roomID.ToString());
                }
            }

            progress_bar.Visibility = Visibility.Collapsed;

            if (send!=null)
            {
                send.Invoke(outletid);
            }
        }

        private void btn_eyes_Click(object sender, RoutedEventArgs e)
        {
            Button temp = sender as Button;

            Room_DTO room = temp.DataContext as Room_DTO;

            if (manage_bed != null)
            {
                manage_bed.Invoke(room.roomID.ToString());
            }
        }

        public void Search_Room(string room_name)
        {
            if (room_name != "")
            {
                List<Room_DTO> list_temp = new List<Room_DTO>();

                foreach (Room_DTO temp in list_room_current)
                {
                    if (temp.roomName.ToLower() == room_name.ToLower())
                    {
                        list_temp.Add(temp);
                    }
                }

                list_itemroom.ItemsSource = list_temp;
            }
        }
        public void Restore()
        {
            list_itemroom.ItemsSource = list_room_current;
        }
    }
}
