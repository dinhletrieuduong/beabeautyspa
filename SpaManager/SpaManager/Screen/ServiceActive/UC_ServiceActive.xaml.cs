using DTO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpaManager.Screen.ServiceActive
{
    /// <summary>
    /// Interaction logic for ServiceActive.xaml
    /// </summary>
    public partial class UC_ServiceActive : UserControl
    {
        public UC_ServiceActive()
        {
            InitializeComponent();

            LoadCboOutlet();
        }


        List<Outlet_DTO> list = new List<Outlet_DTO>();
        private async void LoadCboOutlet()
        {
            List<Outlet_DTO> listoutlet = new List<Outlet_DTO>();

            listoutlet = await RestAPI.GetOulet();

            list = listoutlet;

            foreach(Outlet_DTO temp in listoutlet)
            {
                cb_outlet.Items.Add(temp.outlet_name);
            }

            cb_outlet.SelectedIndex = 0;

            Start_State(0);
        }

        
        List<Service_DTO> listservice_active = new List<Service_DTO>();
        private async void Start_State(int index)
        {
            Outlet_DTO outlet = list[index];

            listservice_active = await RestAPI.GetServiceOutlet(outlet.outlet_id.ToString());
            list_serviceactive.ItemsSource = listservice_active;

            progress_bar.Visibility = Visibility.Collapsed;

            LoadListNotActive();
        }

        private async void cb_outlet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            progress_bar.Visibility = Visibility.Visible;
            progress_bar2.Visibility = Visibility.Visible;

            int outlet_id = 0;

            int index = cb_outlet.SelectedIndex;

            string outlet_name = cb_outlet.Items[index].ToString();

            foreach (Outlet_DTO temp in list)
            {
                if(temp.outlet_name == outlet_name)
                {
                    outlet_id = temp.outlet_id;
                    break;
                }
            }

            List<Service_DTO> listservice = await RestAPI.GetServiceOutlet(outlet_id.ToString());

            listservice_active = listservice;

            list_serviceactive.ItemsSource = listservice;
            progress_bar.Visibility = Visibility.Collapsed;
            LoadListNotActive();
           
        }

        private async void LoadListNotActive()
        {
            List<Service_DTO> listserviceall = new List<Service_DTO>();

            listserviceall = await RestAPI.GetService();

            foreach(Service_DTO temp in listservice_active)
            {
                bool result = listserviceall.Exists(x => x.service_id == temp.service_id);

                if(result)
                {
                    foreach (Service_DTO temp1 in listserviceall)
                    {
                        if (temp1.service_id == temp.service_id)
                        {
                            listserviceall.Remove(temp1);
                            break;
                        }
                    }
                }
            }

            list_servicenotactive.ItemsSource = listserviceall;
            progress_bar2.Visibility = Visibility.Collapsed;
        }

        private void list_serviceactive_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridCellInfo temp = list_serviceactive.SelectedCells[0];

            Service_DTO service = temp.Item as Service_DTO;
            MessageBox.Show(service.service_name);
        }

        private async void btn_disable_Click(object sender, RoutedEventArgs e)
        {
            progress_bar.Visibility = Visibility.Visible;
            progress_bar2.Visibility = Visibility.Visible;

            DataGridCellInfo temp = list_serviceactive.SelectedCells[0];
            Service_DTO service = temp.Item as Service_DTO;

            string outlet_name = cb_outlet.SelectedItem.ToString();
            int outlet_id = -1;

            foreach(Outlet_DTO temp1 in list)
            {
                if(temp1.outlet_name == outlet_name)
                {
                    outlet_id = temp1.outlet_id;
                    break;
                }
            }

            DeactiveRequest deactive = new DeactiveRequest();

            deactive.service_id = service.service_id;
            deactive.outlet_id = outlet_id;

            bool result = await RestAPI.PostServiceHandle(deactive, "deactive");

            
            Start_State(cb_outlet.SelectedIndex);
        }
        
        private async void btn_enable_Click(object sender, RoutedEventArgs e)
        {
            progress_bar.Visibility = Visibility.Visible;
            progress_bar2.Visibility = Visibility.Visible;

            DataGridCellInfo temp = list_servicenotactive.SelectedCells[0];
            Service_DTO service = temp.Item as Service_DTO;

            string outlet_name = cb_outlet.SelectedItem.ToString();
            int outlet_id = -1;

            foreach (Outlet_DTO temp1 in list)
            {
                if (temp1.outlet_name == outlet_name)
                {
                    outlet_id = temp1.outlet_id;
                    break;
                }
            }

            DeactiveRequest deactive = new DeactiveRequest();

            deactive.service_id = service.service_id;
            deactive.outlet_id = outlet_id;

            bool result = await RestAPI.PostServiceHandle(deactive, "active");

            Start_State(cb_outlet.SelectedIndex);
        }
    }
}
