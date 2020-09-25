using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Win32;
using SpaManager.ApiConnection;
using SpaManager.Form.CreateOutlet;
using SpaManager.Form.CreateService;
using SpaManager.Model;

namespace SpaManager.Screen.Service
{
    /// <summary>
    /// Interaction logic for UC_Service.xaml
    /// </summary>
    public partial class UC_Service : UserControl
    {
        public UC_Service()
        {
            InitializeComponent();

            _Load();
        }

        public delegate void Reload();
        public Reload send;

        List<Service_DTO> list_service_current = new List<Service_DTO>();
        private async void _Load()
        {
            List<Service_DTO> listservice = new List<Service_DTO>();

            
            listservice = await RestAPI.GetService();
            list_service_current = listservice;

            list_itemservice.ItemsSource = listservice;

            progress_bar.Visibility = Visibility.Collapsed;
        }

        private async void btn_create_Click(object sender, RoutedEventArgs e)
        {
            FormCreateService form = new FormCreateService();

            form.ShowDialog();

            if (form.status)
            {
                progress_bar.Visibility = Visibility.Visible;

                ServiceResquest service = new ServiceResquest();

                service.service_name = form.getServiceName();
                service.service_description = form.getServiceDescription();
                service.service_duration = form.getServiceDuration();
                service.service_transit = form.getServiceTransit();
                service.service_cost = form.getServiceCost();

                service.pathPhoto = form.getPathPhoto();
                service.filePhoto = File.ReadAllBytes(service.pathPhoto);

                if (await RestAPI.CreateService(service))
                {
                    progress_bar.Visibility = Visibility.Collapsed;

                    MessageBox.Show("Create Service Successful");

                    if (send != null)
                    {
                        send.Invoke();
                    }
                }
                else
                {
                    progress_bar.Visibility = Visibility.Collapsed;

                    MessageBox.Show("Fail");
                }
            }
        }

        private async void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            progress_bar.Visibility = Visibility.Visible;

            List<Service_DTO> list = list_itemservice.ItemsSource as List<Service_DTO>;

            foreach(Service_DTO temp in list)
            {
                if(temp.service_check)
                {
                    DelServiceRequest request = new DelServiceRequest();

                    request.service_id = temp.service_id;

                    bool result = await RestAPI.PostDeleteService(request);
                }
            }
            progress_bar.Visibility = Visibility.Collapsed;

            if(send!=null)
            {
                send.Invoke();
            }

        }

        private void btn_selectall_Checked(object sender, RoutedEventArgs e)
        {
            Handle_SelectAll(true);
        }

        private void btn_selectall_Unchecked(object sender, RoutedEventArgs e)
        {
            Handle_SelectAll(false);
        }

        private void Handle_SelectAll(bool value)
        {
            List<Service_DTO> list_temp = new List<Service_DTO>();

            foreach (Service_DTO temp in list_service_current)
            {
                temp.service_check = value;
                list_temp.Add(temp);
            }

            list_itemservice.ItemsSource = list_temp;
        }

        public void Search_Service(string service_name)
        {
            if (service_name != "")
            {
                List<Service_DTO> list_temp = new List<Service_DTO>();

                foreach (Service_DTO temp in list_service_current)
                {
                    if (temp.service_name.ToLower() == service_name.ToLower())
                    {
                        list_temp.Add(temp);
                    }
                }

                list_itemservice.ItemsSource = list_temp;
            }
        }

        public void Restore()
        {
            list_itemservice.ItemsSource = list_service_current;
        }
    }
}
