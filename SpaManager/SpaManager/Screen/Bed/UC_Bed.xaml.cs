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
using SpaManager.Form.CreateBed;
using SpaManager.Model;

namespace SpaManager.Screen.Bed
{
    /// <summary>
    /// Interaction logic for UC_Bed.xaml
    /// </summary>
    public partial class UC_Bed : UserControl
    {
        string roomid = String.Empty;
        public UC_Bed(string room_id)
        {
            InitializeComponent();

          
            _Load(room_id);
        }

        public delegate void Reload(string room_id);
        public Reload send;

        List<Bed_DTO> list_bed_current = new List<Bed_DTO>();
        private async void _Load(string room_id)
        {
            List<Bed_DTO> list = new List<Bed_DTO>();

            list = await RestAPI.GetBed(room_id);

            list_bed_current = list;
            progress_bar.Visibility = Visibility.Collapsed;

            list_itembed.ItemsSource = list;

            roomid = room_id;
        }

        private async void btn_create_Click(object sender, RoutedEventArgs e)
        {
            FormCreateBed form = new FormCreateBed();

            form.ShowDialog();

            if(form.status)
            {
                BedRequest request = new BedRequest();

                request.room_id = Int32.Parse(roomid);
                request.bed_name = form.Get_BedName();

                progress_bar.Visibility = Visibility.Visible;

                if (await RestAPI.CreateBed(request))
                {
                    progress_bar.Visibility = Visibility.Collapsed;

                    if (send!=null)
                    {
                        send.Invoke(roomid);
                    }
                    MessageBox.Show("Create Bed Successfull");
                }
                else
                {
                    progress_bar.Visibility = Visibility.Collapsed;

                    MessageBox.Show("Create Bed Fail");
                }
            }
        }

        private async void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            progress_bar.Visibility = Visibility.Visible;

            List<Bed_DTO> listbed = list_itembed.ItemsSource as List<Bed_DTO>;

            foreach(var temp in listbed)
            {
                if(temp.bed_check)
                {
                    bool result = await RestAPI.PostDeleteBed(temp.bedID.ToString()); 
                }
            }

            progress_bar.Visibility = Visibility.Collapsed;

            if (send!=null)
            {
                send.Invoke(roomid);
            }
        }

        public void Search_Bed(string bed_name)
        {
            if (bed_name != "")
            {
                List<Bed_DTO> list_temp = new List<Bed_DTO>();

                foreach (Bed_DTO temp in list_bed_current)
                {
                    if (temp.bedName.ToLower() == bed_name.ToLower())
                    {
                        list_temp.Add(temp);
                    }
                }

                list_itembed.ItemsSource = list_temp;
            }
        }

        public void Restore()
        {
            list_itembed.ItemsSource = list_bed_current;
        }
    }
}
