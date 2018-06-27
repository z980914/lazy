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
using System.Windows.Threading;
using Microsoft.Win32;
using System.IO;
using System.Windows.Ink;



namespace WpfApplication1
{
    /// <summary>  

    /// 定义一个定时器

    /// </summary>


    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        private DispatcherTimer ShowTimer;
        public MainWindow()
        {
            InitializeComponent();
            ShowTime();
            ShowTimer = new System.Windows.Threading.DispatcherTimer();
            ShowTimer.Tick += new EventHandler(ShowCurTimer);//起个Timer一直获取当前时
            ShowTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            ShowTimer.Start();

        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public void ShowCurTimer(object sender, EventArgs e)

        {

            ShowTime();

        }
        private void ShowTime()
        {
            //获得年月日
            this.tbDateText.Text = DateTime.Now.ToString("yyyy/MM/dd");   //yyyy/MM/dd
            //获得时分秒
            this.tbTimeText.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Ink Serialized Format (*.isf)|*.isf|" +
                         "Bitmap files (*.bmp)|*.bmp";

            if ((bool)dlg.ShowDialog(this))
            {
                try
                {
                    using (FileStream file = new FileStream(dlg.FileName,
                                            FileMode.Create, FileAccess.Write))
                    {
                        //Ink Serialized Format
                        if (dlg.FilterIndex == 1)
                        {
                            this.ink.Strokes.Save(file);
                            file.Close();
                        }
                        //bitmap object
                        else
                        {
                            int marg = int.Parse(this.ink.Margin.Left.ToString());
                            RenderTargetBitmap rtb = new RenderTargetBitmap((int)this.ink.ActualWidth - marg,
                                            (int)this.ink.ActualHeight - marg, 0, 0, PixelFormats.Default);
                            rtb.Render(this.ink);
                            BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                            encoder.Frames.Add(BitmapFrame.Create(rtb));
                            encoder.Save(file);
                            file.Close();
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, Title);
                }

            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ink.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }

        private void TimeControl_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("菜鸡");
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
           UserControl1  item = new UserControl1();
            Father.Children.Add(item);
           
        }
        int i = 0;
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            image.Source = (ImageSource)new BitmapImage(new Uri( "Images" + ((i++ % 100) + 1) + ".png",
                   UriKind.RelativeOrAbsolute));
            if (i==3)
            {
                i = 0;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ink.EditingMode = InkCanvasEditingMode.Ink;
        }
    }
    }


