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
using SpaDTO;

namespace SpaManager
{
    /// <summary>
    /// Interaction logic for LocalMangerxaml.xaml
    /// </summary>
    public partial class ManageAccount : UserControl
    {
        public ManageAccount()
        {
            InitializeComponent();

            Menu window = new Menu();

            st_menu.Children.Clear();
            st_menu.Children.Add(window);

            Bar bar = new Bar();

            st_bar.Children.Clear();
            st_bar.Children.Add(bar);

            List<Test> temp = new List<Test>();

            temp.Add(new Test { Username = "Phan Trong Hieu", Status = "Active", Block = "Block" });
            temp.Add(new Test { Username = "Dinh Le Trieu Duong", Status = "Active", Block = "Check" });

            list_user.ItemsSource = temp;
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Test temp = btn.DataContext as Test;

            MessageBox.Show(temp.Username);
        }
    }
}
