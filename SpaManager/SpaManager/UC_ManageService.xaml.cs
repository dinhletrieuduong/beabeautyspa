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
    /// Interaction logic for UC_ManageService.xaml
    /// </summary>
    public partial class UC_ManageService : UserControl
    {
        public UC_ManageService()
        {
            InitializeComponent();

            List<Service> list = new List<Service>();

            list.Add(new Service
            {
                service_name = "Massage 1",
                service_cost = "10$",
                service_start_date = "8h30 AM 31/02/2019",
                service_end_date = "8h30 AM 31/02/2020",
                service_status = "Enable",
                service_check = false
            });

            list.Add(new Service
            {
                service_name = "Massage 2",
                service_cost = "10$",
                service_start_date = "8h30 AM 31/02/2019",
                service_end_date = "8h30 AM 31/02/2020",
                service_status = "Enable",
                service_check = false
            });

            list_itemservice.ItemsSource = list;
        }
    }
}
