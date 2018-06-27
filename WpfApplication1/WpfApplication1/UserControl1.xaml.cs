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

namespace WpfApplication1
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        
        public UserControl1()
        {
            InitializeComponent();
        }
        private void CheckMark_MouseDown(object sender, MouseButtonEventArgs e)
        {
          
          
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CheckMark.Visibility == Visibility.Hidden&& CheckMark2.Visibility == Visibility.Hidden)
            {
                CheckMark.Visibility = Visibility.Visible;
                CheckMark2.Visibility = Visibility.Visible;
            }
           else if (CheckMark.Visibility == Visibility.Visible&& CheckMark2.Visibility == Visibility.Visible)
            {
                CheckMark.Visibility = Visibility.Hidden;
                CheckMark2.Visibility = Visibility.Hidden;
            }
             
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            int i = rand.Next(1, 5);
            if (i==1)
            {
                colorful.Background = new SolidColorBrush(Colors.Red);
            }
            else if (i==2)
            {
                colorful.Background = new SolidColorBrush(Colors.Yellow);
            }
            else if (i==3)
            {
                colorful.Background = new SolidColorBrush(Colors.Green);
            }
            else if (i == 4)
            {
                colorful.Background = new SolidColorBrush(Colors.Blue);
            }
            else
            {
                colorful.Background = new SolidColorBrush(Colors.Gray);
            }
        }
    }
}
