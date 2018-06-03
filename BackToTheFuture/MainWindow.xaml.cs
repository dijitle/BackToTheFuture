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

            timeDestination.Value = null;
            timeDestination.LEDColor = Brushes.Red;
            timeDestination.TextLabel = "Destination Time";

            timePresent.Value = null;
            timePresent.LEDColor = Brushes.Green;
            timePresent.TextLabel = "Present Time";

            timeDeparted.Value = null; 
            timeDeparted.LEDColor = Brushes.Yellow;
            timeDeparted.TextLabel = "Last Time Departed";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timeDestination.Dispose();
            timePresent.Dispose();
            timeDeparted.Dispose();
        }

        private void Button_ClickON(object sender, RoutedEventArgs e)
        {
            timeDestination.Value = new DateTime(2015, 10, 21, 4, 29, 00);
            timeDestination.TurnOn();

            timePresent.Value = DateTime.Now;
            timePresent.TurnOn(true);

            timeDeparted.Value = new DateTime(1955, 11, 12, 6, 38, 00); 
            timeDeparted.TurnOn();

        }

        private void Button_ClickOFF(object sender, RoutedEventArgs e)
        {
            timeDestination.TurnOff();
            timePresent.TurnOff();
            timeDeparted.TurnOff();

        }
    }
}
