using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace VaralbaControls
{
    public enum TextBoxType
    {
        NUMBER,
        STRING,
        ALL,
    }
    public class CuTextBox : TextBox
    {
        public TextBoxType TextType { get; set; } = TextBoxType.ALL;

        string regex_pattern_text = "[a-zA-Zа-яА-яё]+";
        public CuTextBox()
        {
            
            this.BorderThickness = new System.Windows.Thickness(0);
            this.Foreground = Brushes.White;
            this.BorderBrush = this.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(1, 0, 0, 0));

            this.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left;
            this.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
            
            //this.KeyDown += (o, e) =>
            //{

            //    if(e.Key == System.Windows.Input.Key.Enter)
            //    {
            //        string str_ = "";
            //        switch (TextType)
            //        {
            //            case TextBoxType.NUMBER:
                            
            //                if (Regex.IsMatch(this.Text, "[0-9]+"))
            //                {

            //                    foreach (Match item in Regex.Matches(this.Text, "[0-9]+"))
            //                    {
            //                        str_ += item.Value;
            //                    }
            //                    this.Text = str_;
            //                }

                            
            //                break;
            //            case TextBoxType.STRING:
                            
                          
            //                if (Regex.IsMatch(this.Text, regex_pattern_text))
            //                {

            //                    foreach (Match item in Regex.Matches(this.Text, regex_pattern_text))
            //                    {
            //                        str_ += item.Value;
            //                    }
            //                    this.Text = str_;
            //                }

            //                break;
            //            case TextBoxType.ALL:
            //                break;
            //            default:
            //                break;
            //        }
            //    }
            //};
        }
        
 

    }
}
