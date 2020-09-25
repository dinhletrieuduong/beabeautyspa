using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DTO;
using Microsoft.Win32;
using SpaManager.ApiConnection;
using SpaManager.Form.CreateOutlet;
using SpaManager.Model;


namespace SpaManager.Screen.Outlet
{
    /// <summary>
    /// Interaction logic for UC_Outlet.xaml
    /// </summary>
    public partial class UC_Outlet : UserControl
    {
        public UC_Outlet()
        {
            InitializeComponent();

            _Load();
        }

        public delegate void ReLoad();
        public ReLoad send;

        public delegate void ManageDash(string str);
        public ManageDash room;

        public ReLoad ViewService;

        List<Outlet_DTO> list_outlet_current = new List<Outlet_DTO>();
        private async void _Load()
        {
            List<Outlet_DTO> listoutlet = new List<Outlet_DTO>();


            listoutlet = await RestAPI.GetOulet();
            list_outlet_current = listoutlet;

            progress_bar.Visibility = Visibility.Collapsed;

            list_itemoutlet.ItemsSource = listoutlet;

           
        }

        private async void btn_create_Click(object sender, RoutedEventArgs e)
        {

            FormCreateOutlet form = new FormCreateOutlet();

            form.ShowDialog();
            
            if(form.status)
            {
                progress_bar.Visibility = Visibility.Visible;
                OutletRequest outlet = new OutletRequest();

                outlet.outletName = form.getOuletName();
                outlet.outletAddress = form.getOutletAddress();
                outlet.pathPhoto = form.getPathPhoto();

                outlet.filePhoto = File.ReadAllBytes(form.getPathPhoto());

                if(await RestAPI.CreateOutlet(outlet))
                {
                    progress_bar.Visibility = Visibility.Collapsed;
                    MessageBox.Show("Create Outlet Successful");
                    if(send!=null)
                    {
                        send.Invoke();
                    }
                }
                else
                {
                    progress_bar.Visibility = Visibility.Collapsed;
                    MessageBox.Show("Create Outlet Fail");
                }
            }
            
        }

        private async void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            progress_bar.Visibility = Visibility.Visible;
            List<Outlet_DTO> list = list_itemoutlet.ItemsSource as List<Outlet_DTO>;

            DelOutletRequest request = new DelOutletRequest();

            foreach(Outlet_DTO temp in list)
            {
                if(temp.outlet_check)
                {
                    request.outlet_id = temp.outlet_id;

                    bool result = await RestAPI.PostDeleteOutlet(request);

                }
            }

            progress_bar.Visibility = Visibility.Collapsed;

            if (send != null)
            {
                send.Invoke();
            }
        }

        private void btn_viewservice_Click(object sender, RoutedEventArgs e)
        {
            if(ViewService!=null)
            {
                ViewService.Invoke();
            }
        }

        private void btn_eyes_Click(object sender, RoutedEventArgs e)
        {
            Button temp = sender as Button;

            Outlet_DTO outlet = temp.DataContext as Outlet_DTO;
            if (room != null)
            {
                room.Invoke(outlet.outlet_id.ToString());
            }
        }

        public void Search_Outlet(string outlet_name)
        {
            if (outlet_name != "")
            {
                List<Outlet_DTO> list_temp = new List<Outlet_DTO>();

                foreach (Outlet_DTO temp in list_outlet_current)
                {
                    if (temp.outlet_name.ToLower() == outlet_name.ToLower())
                    {
                        list_temp.Add(temp);
                    }
                }

                list_itemoutlet.ItemsSource = list_temp;
            }
        }

        public void Restore()
        {
            list_itemoutlet.ItemsSource = list_outlet_current;
        }

        private async void btn_active_Click(object sender, RoutedEventArgs e)
        {
            progress_bar.Visibility = Visibility.Visible;
            List<Outlet_DTO> list = list_itemoutlet.ItemsSource as List<Outlet_DTO>;


            foreach (Outlet_DTO temp in list)
            {
                if (temp.outlet_check)
                {
                    bool result = await RestAPI.PostActiveOutlet(temp.outlet_id.ToString());
                }
            }

            progress_bar.Visibility = Visibility.Collapsed;

            if (send != null)
            {
                send.Invoke();
            }
        }

        private async void btn_deactive_Click(object sender, RoutedEventArgs e)
        {
            progress_bar.Visibility = Visibility.Visible;
            List<Outlet_DTO> list = list_itemoutlet.ItemsSource as List<Outlet_DTO>;


            foreach (Outlet_DTO temp in list)
            {
                if (temp.outlet_check)
                {
                    bool result = await RestAPI.PostDeactiveOutlet(temp.outlet_id.ToString());
                }
            }

            progress_bar.Visibility = Visibility.Collapsed;

            if (send != null)
            {
                send.Invoke();
            }
        }
    }
}
