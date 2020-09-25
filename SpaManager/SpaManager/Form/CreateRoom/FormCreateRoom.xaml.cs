using SpaManager.ApiConnection;
using SpaManager.Model;
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

namespace SpaManager.Form.CreateRoom
{
    /// <summary>
    /// Interaction logic for FormCreateRoom.xaml
    /// </summary>
    public partial class FormCreateRoom : Window
    {
        public FormCreateRoom()
        {
            InitializeComponent();
            _Load();
        }

        public bool status = false;

        List<RoomTypeResponse> listroomtype = new List<RoomTypeResponse>();
        private async void _Load()
        {
            List<RoomTypeResponse> list = new List<RoomTypeResponse>();

            list = await RestAPI.GetRoomType();

            listroomtype = list;

            foreach(var temp in list)
            {
                cb_rtype.Items.Add(temp.room_type_name);
            }
        }
        public string Get_Roomname()
        {
            return txt_roomname.Text;
        }

        public int Get_maxbed()
        {
            return Int32.Parse(txt_maxbed.Text);
        }

        public int Get_RoomTypeID()
        {
            if (cb_rtype.SelectedIndex > -1)
                return listroomtype[cb_rtype.SelectedIndex].room_type_id;

            return -1;
        }
        private void btn_OK_Click(object sender, RoutedEventArgs e)
        {
            status = true;
            this.Close();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {

            status = false;
            this.Close();

        }
    }
}
