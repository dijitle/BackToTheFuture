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

namespace TimeInput
{
    /// <summary>
    /// Interaction logic for TimeInput.xaml
    /// </summary>
    public partial class TimeInput : UserControl
    {
        public TimeInput()
        {
            InitializeComponent();
        }

        public ITimeInput Main { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender == keyEnter)
            {
                Main.SetTime("022219881337");
            }
            else if (sender == keyReset)
            {
                Main.SetTime(string.Empty);
            }
            else
            {

            }
            
        }

        public void PressKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.NumPad0:
                case Key.D0:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(key0, new object[] { true });
                    break;

                case Key.NumPad1:
                case Key.D1:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(key1, new object[] { true });
                    break;

                case Key.NumPad2:
                case Key.D2:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(key2, new object[] { true });
                    break;

                case Key.NumPad3:
                case Key.D3:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(key3, new object[] { true });
                    break;

                case Key.NumPad4:
                case Key.D4:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(key4, new object[] { true });
                    break;

                case Key.NumPad5:
                case Key.D5:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(key5, new object[] { true });
                    break;

                case Key.NumPad6:
                case Key.D6:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(key6, new object[] { true });
                    break;

                case Key.NumPad7:
                case Key.D7:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(key7, new object[] { true });
                    break;

                case Key.NumPad8:
                case Key.D8:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(key8, new object[] { true });
                    break;

                case Key.NumPad9:
                case Key.D9:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(key9, new object[] { true });
                    break;
                case Key.Delete:
                case Key.Back:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(keyDelete, new object[] { true });
                    break;
                case Key.Enter:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(keyEnter, new object[] { true });
                    break;
                case Key.Escape:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(keyReset, new object[] { true });
                    break;

            }
        }

        public void PressKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.NumPad0:
                case Key.D0:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(key0, new object[] { false });
                    key0.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.NumPad1:
                case Key.D1:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(key1, new object[] { false });
                    key1.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.NumPad2:
                case Key.D2:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(key2, new object[] { false });
                    key2.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.NumPad3:
                case Key.D3:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(key3, new object[] { false });
                    key3.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.NumPad4:
                case Key.D4:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(key4, new object[] { false });
                    key4.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.NumPad5:
                case Key.D5:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(key5, new object[] { false });
                    key5.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.NumPad6:
                case Key.D6:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(key6, new object[] { false });
                    key6.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.NumPad7:
                case Key.D7:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(key7, new object[] { false });
                    key7.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.NumPad8:
                case Key.D8:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(key8, new object[] { false });
                    key8.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.NumPad9:
                case Key.D9:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(key9, new object[] { false });
                    key9.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Delete:
                case Key.Back:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(keyDelete, new object[] { false });
                    keyDelete.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Enter:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(keyEnter, new object[] { false });
                    keyEnter.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Escape:
                    typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(keyReset, new object[] { false });
                    keyReset.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

            }
        }
    }
}
