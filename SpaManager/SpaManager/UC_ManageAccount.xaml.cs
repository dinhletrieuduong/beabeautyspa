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
    /// Interaction logic for UC_ManageAccount.xaml
    /// </summary>
    public partial class UC_ManageAccount : UserControl
    {
        public UC_ManageAccount()
        {
            InitializeComponent();

            List<Test> temp = new List<Test>();

            temp.Add(new Test { Username = "Phan Trong Hieu", Status = "Active", Block = "Block" });
            temp.Add(new Test { Username = "Dinh Le Trieu Duong", Status = "Active", Block = "Check" });

            list_user.ItemsSource = temp;
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
