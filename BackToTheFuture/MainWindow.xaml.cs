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
using System.Threading;

namespace BackToTheFuture
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            timeDestination.Value = DateTime.Now;
            timeDestination.LEDColor = "Orange";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(new ThreadStart(cycle));
            t.Start();

        }

        private void cycle()
        {


            for (int i = 0; i <= 99; i++)
            {
                setValue(i);
                Thread.Sleep(100);
            }
        }

        private void setValue(int i)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(new Action(() => setValue(i)));
            }
            else
            {
                //lg1.Value = i;
            }
        }
    }
}
