using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading;

namespace Pod
{
    /// <summary>
    /// Interaction logic for Pod.xaml
    /// </summary>
    public partial class Pod : UserControl, INotifyPropertyChanged, IDisposable
    {
        private SolidColorBrush _ledColor;
        private string _textLabel = string.Empty;
        private DateTime? _value;
        private long _startTime;
        private long _initialTime;
        private double _ledBright = LED.LED.LED_DIM;

        private Thread _timeKeepThread = null;
        private bool _runThread = false;
        private bool _keepTime = false;

        public Pod()
        {
            InitializeComponent();                
        }

        public string TextLabel
        {
            get
            {
                return _textLabel.ToUpper();
            }
            set
            {
                _textLabel = value.ToUpper();
                OnPropertyChanged();
            }
        }

        public SolidColorBrush LEDColor
        {
            get
            {
                return _ledColor;
            }
            set
            {
                _ledColor = value;

                podMonth.LEDColor = _ledColor;
                podDay.LEDColor = _ledColor;
                podYear.LEDColor = _ledColor;
                podHour.LEDColor = _ledColor;
                podMinute.LEDColor = _ledColor;

                OnPropertyChanged();
            }
        }

        public double LEDBright
        {
            get
            {
                return _ledBright;
            }
            set
            {
                _ledBright = value;
                OnPropertyChanged();
            }
        }

        public DateTime? Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;

                if (value == null)
                {
                    podMonth.Value = string.Empty;
                    podDay.Value = string.Empty;
                    podYear.Value = string.Empty;
                    podHour.Value = string.Empty;
                    podMinute.Value = string.Empty;
                    _runThread = false;
                }
                else
                {                    
                    podMonth.Value = _value.Value.ToString("MMM");
                    podDay.Value = _value.Value.ToString("dd");
                    podYear.Value = _value.Value.ToString("yyyy");
                    podHour.Value = _value.Value.ToString("HH");
                    podMinute.Value = _value.Value.ToString("mm");
                }
            }
        }

        public void TurnOn(DateTime currentTime, bool keepTime = false)
        {
            while (_timeKeepThread != null && _timeKeepThread.IsAlive)
            {
                _runThread = false;
                Thread.Sleep(1000);
            }
            _runThread = true;
            _keepTime = keepTime;
            _startTime = DateTime.Now.Ticks;
            _initialTime = currentTime.Ticks;
            Value = currentTime;
            _timeKeepThread = new Thread(() => KeepTimeThread());
            _timeKeepThread.Start();
        }

        public void TurnOff()
        {
            if (_timeKeepThread != null && _timeKeepThread.IsAlive)
            {
                _runThread = false;
            }
            Value = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void KeepTimeThread()
        {
            while (_runThread)
            {
                if (_keepTime)
                {
                    Value = new DateTime(_initialTime + (new TimeSpan(DateTime.Now.Ticks - _startTime).Ticks));
                }
                LEDBright = LEDBright == LED.LED.LED_DIM ? LED.LED.LED_ON : LED.LED.LED_DIM;
                Thread.Sleep(1000 - DateTime.Now.Millisecond);
            }
        }

        public void Dispose()
        {
            if (_timeKeepThread != null && _timeKeepThread.IsAlive)
            {
                _runThread = false;
            }
        }
    }
}
