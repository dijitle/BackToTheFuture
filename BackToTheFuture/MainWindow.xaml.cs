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
        private string _input = string.Empty;

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

        private void Button_ClickSET(object sender, RoutedEventArgs e)
        {
            if (_input == string.Empty)
            {
                timeDestination.TurnOff();
            }
            else
            {
                int yr, mo, dy, hr, mn;
                try
                {
                    yr = Convert.ToInt32(_input.Substring(4, 4));
                }
                catch
                {
                    yr = DateTime.Now.Year;
                }

                try
                {
                    mo = Convert.ToInt32(_input.Substring(0, 2));
                }
                catch
                {
                    mo = DateTime.Now.Month;
                }

                try
                {
                    dy = Convert.ToInt32(_input.Substring(2, 2));
                }
                catch
                {
                    dy = DateTime.Now.Day;
                }

                try
                {
                    hr = Convert.ToInt32(_input.Substring(8, 2));
                }
                catch
                {
                    hr = DateTime.Now.Day;
                }

                try
                {
                    mn = Convert.ToInt32(_input.Substring(10, 2));
                }
                catch
                {
                    mn = DateTime.Now.Day;
                }



                DateTime d = new DateTime(yr,mo,dy,hr,mn,0);
                timeDestination.Value = d;
                _input = string.Empty;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.NumPad0:
                case Key.D0:
                    _input += "0";
                    break;

                case Key.NumPad1:
                case Key.D1:
                    _input += "1";
                    break;

                case Key.NumPad2:
                case Key.D2:
                    _input += "2";
                    break;

                case Key.NumPad3:
                case Key.D3:
                    _input += "3";
                    break;

                case Key.NumPad4:
                case Key.D4:
                    _input += "4";
                    break;

                case Key.NumPad5:
                case Key.D5:
                    _input += "5";
                    break;

                case Key.NumPad6:
                case Key.D6:
                    _input += "6";
                    break;

                case Key.NumPad7:
                case Key.D7:
                    _input += "7";
                    break;

                case Key.NumPad8:
                case Key.D8:
                    _input += "8";
                    break;

                case Key.NumPad9:
                case Key.D9:
                    _input += "9";
                    break;

            }
        }
    }
}
