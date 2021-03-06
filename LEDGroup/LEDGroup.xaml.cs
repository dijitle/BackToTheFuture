﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LEDGroup
{
    /// <summary>
    /// Interaction logic for LEDGroup.xaml
    /// </summary>
    public partial class LEDGroup : UserControl, INotifyPropertyChanged
    {
        private SolidColorBrush _ledColor;
        private int _size;
        private string _textLabel = string.Empty;
        private string _value;

        public LEDGroup()
        {
            InitializeComponent();
            TextLabel = "hour";

            LEDSize = 2;
            Value = "0";
            
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

        public int LEDSize
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                OnPropertyChanged("Show3");
                OnPropertyChanged("Show4");
            }
        }

        public string Show3 { get { return (_size >= 3) ? "1*" : "0*"; } }
        public string Show4 { get { return (_size == 4) ? "1*" : "0*"; } }

        public SolidColorBrush LEDColor
        {
            get
            {
                return _ledColor;
            }
            set
            {
                _ledColor = value;

                led1.LEDColor = _ledColor;
                led2.LEDColor = _ledColor;
                led3.LEDColor = _ledColor;
                led4.LEDColor = _ledColor;
            }
        }

        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value.ToLower();

                if (_value != string.Empty)
                {
                    led1.LEDValue = _value.PadLeft(_size, '0')[0];
                    led2.LEDValue = _value.PadLeft(_size, '0')[1];
                    if (_size >= 3)
                    {
                        led3.LEDValue = _value.PadLeft(_size, '0')[2];
                    }
                    if (_size == 4)
                    {
                        led4.LEDValue = _value.PadLeft(_size, '0')[3];
                    }
                }
                else
                {
                    led1.LEDValue = " "[0];
                    led2.LEDValue = " "[0];
                    if (_size >= 3)
                    {
                        led3.LEDValue = " "[0];
                    }
                    if (_size == 4)
                    {
                        led4.LEDValue = " "[0];
                    }
                }
            }
        }

        public LED.LED.LEDType Type
        {
            get
            {
                return led1.Type;
            }
            set
            {
                led1.Type = value;
                led2.Type = value;
                led3.Type = value;
                led4.Type = value;
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
