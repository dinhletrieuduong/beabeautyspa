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

namespace SpaManager.Form.CreateBed
{
    /// <summary>
    /// Interaction logic for FormCreateBed.xaml
    /// </summary>
    public partial class FormCreateBed : Window
    {
        public FormCreateBed()
        {
            InitializeComponent();
        }

        public bool status = false;

        public string Get_BedName()
        {
            return txt_bedname.Text;
        }
        private void btn_OK_Click(object sender, RoutedEventArgs e)
        {
            if (CheckStringNotNull(txt_bedname.Text))
            {
                status = true;
                this.Close();
            }
            else
            {
                
                txt_bedname.BorderBrush = Brushes.Red;
                
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            status = false;
            this.Close();
        }

        private bool CheckStringNotNull(string str)
        {
            if (str == "")
                return false;

            return true;
        }
    }
}
