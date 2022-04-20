 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace VaralbaControls
{
    public class LBorder : Border
    {
        Label _label;


        public string SelectClass
        {
            get; set;
        } = string.Empty;

        public LBorder()
        {
            _label = new Label()
            {
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Foreground = Brushes.White,
                Margin = new Thickness(0),
                Padding = new Thickness(0),
                SnapsToDevicePixels = true,
                RenderTransformOrigin = new System.Windows.Point(0.5, 0.5),
            };
            this.SnapsToDevicePixels = true;
           
            this.Child = _label;

            



            //_label.Style = this.FindResource("LabelStyle_") as Style;
        }
        public double FontSize
        {
            get
            {
                return _label.FontSize;
            }
            set
            {
                _label.FontSize = value;
            }
        }
         

        public Thickness LabelMargin
        {
            get { return _label.Margin; }
            set { _label.Margin = value; }
        }
        public HorizontalAlignment LabelHorizontal
        {
            get { return _label.HorizontalContentAlignment; }
            set { _label.HorizontalContentAlignment = value; }
        }
        public VerticalAlignment LabelVertical
        {
            get { return _label.VerticalContentAlignment; }
            set { _label.VerticalContentAlignment = value; }
        }
        public Brush Foreground
        {
            get
            {
                return _label.Foreground;
            }
            set
            {
                _label.Foreground = value;
            }
        }
         
        public FontFamily LabelFontFamily
        {
            get
            {
                return _label.FontFamily;
            }
            set
            {
                _label.FontFamily = value;
            }
        }
        public object Content
        {
            get
            {
                return _label.Content;
            }
            set
            {
                _label.Content = value;
            }
        }
        public Style LabelStyle
        {
            get
            {
                return _label.Style;
            }
            set
            {
                _label.Style = value;
            }
        }

    }
}
