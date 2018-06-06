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
using BackToTheFuture;

namespace BackToTheFuture
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, PowerSwitch.IPowerSwitch, TimeInput.ITimeInput
    {
        private string _input = string.Empty;

        public MainWindow()
        {
            InitializeComponent();

            TurnOff();

            powerSwitch.Main = this;
            timeInput.Main = this;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timeDestination.Dispose();
            timePresent.Dispose();
            timeDeparted.Dispose();
        }

        public void TurnOn()
        {
            timeDestination.TurnOn(new DateTime(2015, 10, 21, 4, 29, 00));
            timePresent.TurnOn(DateTime.Now, true);
            timeDeparted.TurnOn(new DateTime(1955, 11, 12, 6, 38, 00));
        }

        public void TurnOff()
        {
            timeDestination.TurnOff();
            timePresent.TurnOff();
            timeDeparted.TurnOff();
        }

        public void SetTime(string input)
        {
            if (input == string.Empty)
            {
                timeDestination.TurnOff();
            }
            else
            {
                int yr, mo, dy, hr, mn;
                try
                {
                    yr = Convert.ToInt32(input.Substring(4, 4));
                }
                catch
                {
                    yr = DateTime.Now.Year;
                }

                try
                {
                    mo = Convert.ToInt32(input.Substring(0, 2));
                }
                catch
                {
                    mo = DateTime.Now.Month;
                }

                try
                {
                    dy = Convert.ToInt32(input.Substring(2, 2));
                }
                catch
                {
                    dy = DateTime.Now.Day;
                }

                try
                {
                    hr = Convert.ToInt32(input.Substring(8, 2));
                }
                catch
                {
                    hr = DateTime.Now.Day;
                }

                try
                {
                    mn = Convert.ToInt32(input.Substring(10, 2));
                }
                catch
                {
                    mn = DateTime.Now.Day;
                }

                DateTime d = new DateTime(yr, mo, dy, hr, mn, 0);
                timeDestination.TurnOn(d);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            timeInput.PressKeyDown(sender, e);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            timeInput.PressKeyUp(sender, e);
        }
    }
}
