using DTO;
using SpaManager.ApiConnection;
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

namespace SpaManager.Screen.Appointment
{
    /// <summary>
    /// Interaction logic for UC_Appointment.xaml
    /// </summary>
    public partial class UC_Appointment : UserControl
    {
        public UC_Appointment()
        {
            InitializeComponent();

            _Load();
        }

        private async void _Load ()
        {
            List<Appointment_DTO> list = new List<Appointment_DTO>();

            list = await RestAPI.GetAppointment();

            list_itemappt.ItemsSource = list;
            progress_bar.Visibility = Visibility.Collapsed;
        }
    }
}
