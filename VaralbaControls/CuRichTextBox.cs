using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace VaralbaControls
{
    public class CuRichTextBox : RichTextBox
    {
         

       

        public CuRichTextBox()
        {
            this.Background = null;
            this.BorderThickness = new System.Windows.Thickness(0);
            this.Foreground = Brushes.White;
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            this.IsReadOnly = true;
            this.FontSize = 15;
        }
        public string Text
        {
            get
            {
                return new TextRange(this.Document.ContentStart, this.Document.ContentEnd).Text;
            }
            set
            {
                this.Document.Blocks.Clear();
                this.Document.Blocks.Add(new Paragraph(new Run(value)));
            }
        }



         
    }
    public class MessageRichTextBox : Border
    {
        CuRichTextBox cuRichTextBox = new CuRichTextBox();
        public MessageRichTextBox()
        {
            this.CornerRadius = new System.Windows.CornerRadius(0, 10, 0, 10);

            this.Background = new System.Windows.Media.SolidColorBrush(Color.FromArgb(10, 255, 255, 255));
            this.Child = cuRichTextBox;
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            this.Padding = new System.Windows.Thickness(0, 7, 0, 7);
            this.Margin = new System.Windows.Thickness(0, 4, 0, 4);
            this.MaxWidth = 400;

            


        }
        public string Text
        {
            get
            {
                return cuRichTextBox.Text;
            }
            set
            {
                cuRichTextBox.Text = value;
            }
        }
    }
}
