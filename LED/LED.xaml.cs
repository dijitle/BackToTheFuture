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
        private int _ledValue;
        private double _gapThickness;

        private const double LED_ON = 1.0;
        private const double LED_OFF = 0.2;

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

        public int LEDValue
        {
            set
            {
                _ledValue = value % 10;
                OnPropertyChanged("LEDTop");
                OnPropertyChanged("LEDTopLeft");
                OnPropertyChanged("LEDTopRight");
                OnPropertyChanged("LEDMiddle");
                OnPropertyChanged("LEDBottomLeft");
                OnPropertyChanged("LEDBottomRight");
                OnPropertyChanged("LEDBottom");
            }
        }

        public double LEDTop { get { return ( (new[] { 0, 2, 3, 5, 6, 7, 8, 9 }).Contains(_ledValue)) ? LED_ON : LED_OFF; } }
        public double LEDTopLeft { get { return ((new[] { 0, 4, 5, 6, 8, 9 }).Contains(_ledValue)) ? LED_ON : LED_OFF; } }
        public double LEDTopRight { get { return ((new[] { 0, 1, 2, 3, 4, 7, 8, 9 }).Contains(_ledValue)) ? LED_ON : LED_OFF; } }
        public double LEDMiddle { get { return ((new[] { 2, 3, 4, 5, 6, 8, 9 }).Contains(_ledValue)) ? LED_ON : LED_OFF; } }
        public double LEDBottomLeft { get { return ((new[] { 0, 2, 6, 8 }).Contains(_ledValue)) ? LED_ON : LED_OFF; } }
        public double LEDBottomRight { get { return ((new[] { 0, 1, 3, 4, 5, 6, 7, 8, 9 }).Contains(_ledValue)) ? LED_ON : LED_OFF; } }
        public double LEDBottom { get { return ((new[] { 0, 2, 3, 5, 6, 8, 9 }).Contains(_ledValue)) ? LED_ON : LED_OFF; } }


        private Point _potl;
        private Point _potr;
        private Point _poml;
        private Point _pomr;
        private Point _pobl;
        private Point _pobr;
                            
        private Point _pitl;
        private Point _pitr;
        private Point _pitml;
        private Point _pitmr;
        private Point _pibml;
        private Point _pibmr;
        private Point _pibl;
        private Point _pibr;

        public PointCollection LEDPointsTop         { get { return new PointCollection(new[] { _potl, _potr, _pitr, _pitl }); } }
        public PointCollection LEDPointsTopLeft     { get { return new PointCollection(new[] { _potl, _pitl, _pitml, _poml }); } }
        public PointCollection LEDPointsTopRight    { get { return new PointCollection(new[] { _potr, _pitr, _pitmr, _pomr }); } }
        public PointCollection LEDPointsMiddle      { get { return new PointCollection(new[] { _poml, _pitml, _pitmr, _pomr, _pibmr, _pibml }); } }
        public PointCollection LEDPointsBottomLeft  { get { return new PointCollection(new[] { _pobl, _pibl, _pibml, _poml }); } }
        public PointCollection LEDPointsBottomRight { get { return new PointCollection(new[] { _pobr, _pibr, _pibmr, _pomr }); } }
        public PointCollection LEDPointsBottom      { get { return new PointCollection(new[] { _pobl, _pobr, _pibr, _pibl }); } }

        public double GapThickness { get { return _gapThickness; } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double h = ActualHeight; 
            double w = h / 1.6;
            double m = w * .1; //margin
            double t = h * .1; //thickness

            double otop = m;
            double oleft = m;
            double omiddle = h / 2;
            double oright = w - m;
            double obottom = h - m;

            double mtop = h / 2 - t / 2;
            double mbottom = h / 2 + t / 2;

            double itop = m + t;
            double ileft = m + t;
            double iright = w - m - t;
            double ibottom = h - m - t;

            _gapThickness = h * .01;

            _potl = new Point(oleft, otop);
            _potr = new Point(oright, otop);
            _poml = new Point(oleft, omiddle);
            _pomr = new Point(oright, omiddle);
            _pobl = new Point(oleft, obottom);
            _pobr = new Point(oright, obottom);

            _pitl = new Point(ileft, itop);
            _pitr = new Point(iright, itop);
            _pitml = new Point(ileft, mtop);
            _pitmr = new Point(iright, mtop);
            _pibml = new Point(ileft, mbottom);
            _pibmr = new Point(iright, mbottom);
            _pibl = new Point(ileft, ibottom);
            _pibr = new Point(iright, ibottom);

            OnPropertyChanged("LEDPointsTop");
            OnPropertyChanged("LEDPointsTopLeft");
            OnPropertyChanged("LEDPointsTopRight");
            OnPropertyChanged("LEDPointsMiddle");
            OnPropertyChanged("LEDPointsBottomLeft");
            OnPropertyChanged("LEDPointsBottomRight");
            OnPropertyChanged("LEDPointsBottom");

            OnPropertyChanged("GapThickness");
        }
    }
}
