using Microsoft.Win32;
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

namespace SpaManager.Form.CreateService
{
    /// <summary>
    /// Interaction logic for FormCreateService.xaml
    /// </summary>
    public partial class FormCreateService : Window
    {
        public FormCreateService()
        {
            InitializeComponent();
        }

        public bool status = false;
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

        private void btn_path_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();

            if(file.ShowDialog() == true)
            {
                txt_pathimage.Text = file.FileName;
            }
        }

        public string getServiceName()
        {
            return txt_serviceName.Text;
        }

        public string getServiceDescription()
        {
            return txt_serviceDescription.Text;
        }

        public string getServiceDuration()
        {
            return txt_serviceDuration.Text;
        }

        public string getServiceTransit()
        {
            return txt_serviceTransit.Text;
        }

        public string getServiceCost()
        {
            return txt_serviceCost.Text;
        }

        public string getPathPhoto()
        {
            return txt_pathimage.Text;
        }

    }
}
