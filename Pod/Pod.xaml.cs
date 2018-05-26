using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Pod
{
    /// <summary>
    /// Interaction logic for Pod.xaml
    /// </summary>
    public partial class Pod : UserControl, INotifyPropertyChanged
    {
        private SolidColorBrush _ledColor;
        private string _textLabel = string.Empty;
        private DateTime _value;

        public Pod()
        {
            InitializeComponent();

            TextLabel = "Destination time";

            podMonth.TextLabel = "Month";
            podMonth.LEDSize = 3;
            podMonth.Value = "feb";
            podDay.TextLabel = "Day";
            podDay.Value = "22";
            podYear.TextLabel = "Year";
            podYear.LEDSize = 4;
            podYear.Value = "1988";
            podHour.TextLabel = "Hour";
            podHour.Value = "13";                
            podMinute.TextLabel = "Min";
            podMinute.Value = "37";

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

        public DateTime Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                podMonth.Value = _value.ToString("MMM");
                podDay.Value = _value.ToString("dd");
                podYear.Value = _value.ToString("yyyy");
                podHour.Value = _value.ToString("HH");
                podMinute.Value = _value.ToString("mm");
            }
        }

        public string Value2
        {            
            set
            {
                string _value2 = value;
                podMonth.Value = _value2;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
