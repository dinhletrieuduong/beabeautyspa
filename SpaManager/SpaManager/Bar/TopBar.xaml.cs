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

namespace SpaManager.Bar
{
    /// <summary>
    /// Interaction logic for TopBar.xaml
    /// </summary>
    public partial class TopBar : UserControl
    {
        public TopBar(string title)
        {
            InitializeComponent();

            txt_title.Text = title;
        }

        public delegate void BtnSearch(string str);
        public BtnSearch search;

        public delegate void TextNull();
        public TextNull send;
        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            if(search != null)
            {
                search.Invoke(txt_search.Text);

            }
        }

        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txt_search.Text == "")
            {
                if(send!=null)
                {
                    send.Invoke();
                }
            }
        }
    }
}
