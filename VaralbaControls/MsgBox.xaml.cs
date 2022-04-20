using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using VaralbaLib;

namespace VaralbaControls
{
    /// <summary>
    /// Логика взаимодействия для MsgBox.xaml
    /// </summary>
    public partial class MsgBox : UserControl
    {
        

        public MsgBox()
        {
            InitializeComponent();

            this.Loaded += (o, e) =>
            {
                UpdateDateTime();
               
            };
#if !DEBUG
            message_list.Children.Clear();
#endif
        }

        public void SetAvatarImage(string url)
        {
            imageavatar.ImageSource = SImageSource.GetImage(url);
        }
        public void UpdateDateTime()
        {

            DateTime = DATE.GetTime();
        }
        public void AddNewText(string text)
        {

            MessageRichTextBox messageRichTextBox = new MessageRichTextBox();
            messageRichTextBox.Text  = text;
            
            message_list.Children.Add(messageRichTextBox);
        }
        public string DateTime
        {
            get
            {
                return CTime.Content as string;
            }
            set
            {
                CTime.Content = value;
            }
        }
       public string NameUser
        {
            get
            {
                return UserName.Content as string;
            }
            set
            {
                UserName.Content = value;
            }
        }
    }
}
