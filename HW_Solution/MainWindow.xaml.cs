using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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

namespace homeWork_24jul19
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        List<Brush> Colors = new List<Brush>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SafeInvoke(Action work)
        {
            if (Dispatcher.CheckAccess()) 
            {
                work.Invoke();
                return;
            }
            this.Dispatcher.BeginInvoke(work);
        }

        private void FillBrushList()
        {
            Brush result = Brushes.Transparent;
            Type brushesType = typeof(Brushes);
            PropertyInfo[] properties = brushesType.GetProperties();

            for (int i = 0; i < 10; i++)
            {
                int random = rnd.Next(properties.Length);
                result = (Brush)properties[random].GetValue(null, null);
                Colors.Add(result);
            }
        }
        private void PaintBorder()
        {
            Task.Run(() =>
            {
                for (int i = 0; i < Colors.Count; i++)
                {
                    Action uiwork = () => { border1.Background = Colors[i]; };
                    SafeInvoke(uiwork);
                    Thread.Sleep(20);
                }
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FillBrushList();
            Task.Run(() =>
            {
                for (int i = 0; i < Colors.Count; i++)
                {
                    Action uiwork = () => { border1.Background = Colors[i]; };
                    SafeInvoke(uiwork);
                    Thread.Sleep(1000);
                }
            });
        }
    }
}
