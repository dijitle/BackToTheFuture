using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LED
{
    /// <summary>
    /// Interaction logic for LED.xaml
    /// </summary>
    public partial class LED : UserControl, INotifyPropertyChanged
    {
        private SolidColorBrush _ledColor;
        private char _ledValue;

        private const double LED_ON = 1.0;
        private const double LED_DIM = 0.2;
        private const double LED_OFF = 0.0;

        public LED()
        {
            InitializeComponent();
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
                OnPropertyChanged();
            }
        } 

        public char LEDValue
        {
            set
            {
                _ledValue = value;
                OnPropertyChanged("LEDTop");
                OnPropertyChanged("LEDTopLeft");
                OnPropertyChanged("LEDTopRight");
                OnPropertyChanged("LEDWest");
                OnPropertyChanged("LEDEast");
                OnPropertyChanged("LEDBottomLeft");
                OnPropertyChanged("LEDBottomRight");
                OnPropertyChanged("LEDBottom");
                OnPropertyChanged("LEDNorth");
                OnPropertyChanged("LEDNorthEast");
                OnPropertyChanged("LEDNorthWest");
                OnPropertyChanged("LEDSouth");
                OnPropertyChanged("LEDSouthEast");
                OnPropertyChanged("LEDSouthWest");

            }
        }


        public double LEDTop { get { return "02356789".Contains(_ledValue) ? LED_ON : LED_DIM; } }
        public double LEDTopLeft { get { return "045689".Contains(_ledValue) ? LED_ON : LED_DIM; } }
        public double LEDTopRight { get { return "01234789".Contains(_ledValue) ? LED_ON : LED_DIM; } }
        public double LEDWest { get { return "2345689".Contains(_ledValue) ? LED_ON : LED_DIM; } }
        public double LEDEast{ get { return "2345689".Contains(_ledValue) ? LED_ON : LED_DIM; } }
        public double LEDBottomLeft { get { return "0268".Contains(_ledValue) ? LED_ON : LED_DIM; } }
        public double LEDBottomRight { get { return "013456789".Contains(_ledValue) ? LED_ON : LED_DIM; } }
        public double LEDBottom { get { return "0235689".Contains(_ledValue) ? LED_ON : LED_DIM; } }

        public double LEDNorth { get { return LED_OFF; } }
        public double LEDNorthWest { get { return LED_OFF; } }
        public double LEDNorthEast { get { return LED_OFF; } }

        public double LEDSouth { get { return LED_OFF; } }
        public double LEDSouthWest { get { return LED_OFF; } }
        public double LEDSouthEast { get { return LED_OFF; } }

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
