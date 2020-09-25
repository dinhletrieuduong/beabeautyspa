using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace SpaManager.Form.CreateOutlet
{
    /// <summary>
    /// Interaction logic for FormCreateService.xaml
    /// </summary>
    public partial class FormCreateOutlet : Window
    {
        public FormCreateOutlet()
        {
            InitializeComponent();
        }

        public bool status = false;
        private void btn_path_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();

            if(file.ShowDialog() == true)
            {
                txt_pathimage.Text = file.FileName;
            }

        }

        public string getOuletName()
        {
            return txt_outletname.Text;
        }

        public string getOutletAddress()
        {
            return txt_outletaddress.Text;
        }

        public string getPathPhoto()
        {
            return txt_pathimage.Text;
        }

        private void btn_OK_Click(object sender, RoutedEventArgs e)
        {
            status = true;
            this.Close();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            txt_outletname.Text = string.Empty;
            txt_outletaddress.Text = string.Empty;
            txt_pathimage.Text = string.Empty;

            status = false;

            this.Close();
        }

    }
}
