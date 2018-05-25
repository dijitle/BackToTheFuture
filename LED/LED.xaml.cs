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
        private SolidColorBrush _ledColor = Brushes.Red;
        private char _ledValue = '0';

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

        public double LEDTop { get { return "abcdefgimopqrstz02356789".Contains(_ledValue) ? LED_ON : LED_DIM; } }
        public double LEDTopLeft { get { return "acefghklmnopqrsuvy045689".Contains(_ledValue) ? LED_ON : LED_DIM; } }
        public double LEDTopRight { get { return "abdhjmnopqruvwy01234789".Contains(_ledValue) ? LED_ON : LED_DIM; } }
        public double LEDWest { get { return "aefhprsy2345689".Contains(_ledValue) ? LED_ON : LED_DIM; } }
        public double LEDEast{ get { return "abghprsy2345689".Contains(_ledValue) ? LED_ON : LED_DIM; } }
        public double LEDBottomLeft { get { return "acefghjklmnopqruvw0268".Contains(_ledValue) ? LED_ON : LED_DIM; } }
        public double LEDBottomRight { get { return "abdghjmnoqsuw013456789".Contains(_ledValue) ? LED_ON : LED_DIM; } }
        public double LEDBottom { get { return "bcdegijloqsuw0235689".Contains(_ledValue) ? LED_ON : LED_DIM; } }

        public double LEDNorth { get { return "bdimt".Contains(_ledValue) ? LED_ON : "0123456789".Contains(_ledValue) ? LED_OFF : LED_DIM; } }
        public double LEDNorthWest { get { return "n".Contains(_ledValue) ? LED_ON : "0123456789".Contains(_ledValue) ? LED_OFF : LED_DIM; } }
        public double LEDNorthEast { get { return "k".Contains(_ledValue) ? LED_ON : "0123456789".Contains(_ledValue) ? LED_OFF : LED_DIM; } }

        public double LEDSouth { get { return "bditwy".Contains(_ledValue) ? LED_ON : "0123456789".Contains(_ledValue) ? LED_OFF : LED_DIM; } }
        public double LEDSouthWest { get { return "kqrx".Contains(_ledValue) ? LED_ON : "0123456789".Contains(_ledValue) ? LED_OFF : LED_DIM; } }
        public double LEDSouthEast { get { return "vxz".Contains(_ledValue) ? LED_ON : "0123456789".Contains(_ledValue) ? LED_OFF : LED_DIM; } }

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
