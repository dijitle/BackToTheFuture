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
            timeDestination.Value = new DateTime(2015, 10, 21, 4, 29, 00);
            timeDestination.LEDColor = Brushes.Red;
            timeDestination.TextLabel = "Destination Time";

            timePresent.Value = DateTime.Now;
            timePresent.LEDColor = Brushes.Green;
            timePresent.TextLabel = "Present Time";
            timePresent.KeepTime();

            timeDeparted.Value = new DateTime(1955, 11, 12, 6, 38, 00); ;
            timeDeparted.LEDColor = Brushes.Yellow;
            timeDeparted.TextLabel = "Last Time Departed";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(new ThreadStart(cycle));
            t.Start();

        }

        private void cycle()
        {


            for (char i = 'a'; i <= 'z'; i++)
            {
                setValue(i.ToString());
                Thread.Sleep(200);
            }
        }

        private void setValue(string i)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(new Action(() => setValue(i)));
            }
            else
            {
                timeDestination.Value2 = i;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timeDestination.Dispose();
            timePresent.Dispose();
            timeDeparted.Dispose();
        }
    }
}
