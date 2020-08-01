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

            List<Outlet_DTO> list = new List<Outlet_DTO>();

            list.Add(new Outlet_DTO
            {
                outlet_name = "Outlet 1",
                outlet_address = "Address 1",
                outlet_rating = "4",
                outlet_status = "Actived",
                outlet_check = false
            });

            list.Add(new Outlet_DTO
            {
                outlet_name = "Outlet 2",
                outlet_address = "Address 2",
                outlet_rating = "3",
                outlet_status = "Actived",
                outlet_check = false
            });

            list_itemoutlet.ItemsSource = list;
        }
    }
}
