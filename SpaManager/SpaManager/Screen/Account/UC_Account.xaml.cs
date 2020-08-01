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

namespace SpaManager.Screen.Account
{
    /// <summary>
    /// Interaction logic for UC_Account.xaml
    /// </summary>
    public partial class UC_Account : UserControl
    {
        public UC_Account()
        {
            InitializeComponent();

            List<User_DTO> temp = new List<User_DTO>();

            temp.Add(new User_DTO { Username = "Phan Trong Hieu", Status = "Active", Block = "Block" });
            temp.Add(new User_DTO { Username = "Dinh Le Trieu Duong", Status = "Active", Block = "Check" });

            list_user.ItemsSource = temp;
        }
    }
}
