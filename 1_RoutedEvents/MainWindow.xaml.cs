using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace _2807
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi ! I am outter! ");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi ! I am inner! ");
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Title = Mouse.GetPosition(Application.Current.MainWindow).X.ToString();
            Debug.WriteLine("outteeeer " + DateTime.Now.Millisecond);
        }

        private void Button_MouseEnter_1(object sender, MouseEventArgs e)
        {
            this.Title = "Inner " + Mouse.GetPosition(Application.Current.MainWindow).X.ToString();
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("innnnnnnnner " + DateTime.Now.Millisecond);
        }

        private void Button_MouseMove_1(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("outttttttttter " + DateTime.Now.Millisecond);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // e.Handled = true;

            MessageBox.Show("Hi ! I am outter! ");
        }

        private void outter_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("outter key down");
        }

        private void inner_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("Inner key down");
        }

        private void outter_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // opposite way
            MessageBox.Show("outter key down");
        }

        private void inner_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // opposite way
            MessageBox.Show("inner key down");
        }
    }
}
