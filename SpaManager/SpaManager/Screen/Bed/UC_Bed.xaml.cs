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

namespace SpaManager.Screen.Bed
{
    /// <summary>
    /// Interaction logic for UC_Bed.xaml
    /// </summary>
    public partial class UC_Bed : UserControl
    {
        public UC_Bed()
        {
            InitializeComponent();

            List<Bed_DTO> list = new List<Bed_DTO>();

            list.Add(new Bed_DTO { bed_name = "Bed 1", bed_service = "Massage", bed_description = "Description", bed_type = "1", bed_check = false });
            list.Add(new Bed_DTO { bed_name = "Bed 1", bed_service = "Massage", bed_description = "Description", bed_type = "1", bed_check = false });

            list_itembed.ItemsSource = list;
        }
    }
}
