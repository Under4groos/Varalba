using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using VaralbaControls;
using VaralbaLib;

namespace Varalba
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UWebSocket webSocket = new UWebSocket();
         
        string pat_regex_js_ = "(\\{\"[\\w\\W]+\":\"[\\w\\W]+?\",\"[\\w\\W]+\":\"[\\w\\W]+\"?})";

        public MainWindow()
        {
            {
                string folder_svg_icons_ = "SvgIcons";
                if (!Directory.Exists(folder_svg_icons_))
                    Directory.CreateDirectory(folder_svg_icons_);

                foreach ((string, byte[]) item in new List<(string, byte[])>
                {
                    ("c_plus_plus",Properties.Resources.c_plus_plus),
                    ("heart",Properties.Resources.heart),
                     
                })
                {
                    string str = Encoding.UTF8.GetString(item.Item2);
                    string file_cr = System.IO.Path.Combine(folder_svg_icons_, item.Item1 + ".svg");
                    if (!File.Exists(file_cr))
                        File.WriteAllText(file_cr, str);
                }
                
            }

            InitializeComponent();

            {
                new VaralbaLib.WinDragMove(this, winmove);
                WindowResizer windowResizer = new WindowResizer(this);
                windowResizer.addResizerRightDown(resizeborder);
                windowResizer.addResizerRight(resizeborder_l);
                windowResizer.addResizerDown(resizeborder_d);

                new VaralbaLib.WBControl(this, bclose, VaralbaLib.ACTIONS.CLOSE);
                new VaralbaLib.WBControl(this, bmax, VaralbaLib.ACTIONS.SIZE_max);
                new VaralbaLib.WBControl(this, bmin, VaralbaLib.ACTIONS.SIZE_min);

                this.Closed += (o, e) =>
                {
                    webSocket.Close();
                    
                };

                UpdateProfile();


            }
            main();
        }

        void UpdateProfile()
        {
            AvatarImage.ImageSource = SImageSource.GetImage(User.LinkAvatarImage);
            profile_name.Text = User.Name;
            imagelink.Text = User.LinkAvatarImage;
            iphost.Text = webSocket.WebSocketHost;
        }
        void main()
        {



            string last_message = "";
            string name = "";
            string AvatarImage = "";

            webSocket.Init();

            webSocket.NewMessage += (str) =>
            {
                string chat_json = Regex.Match(str, pat_regex_js_).Value;
                dynamic stuff = JsonConvert.DeserializeObject(chat_json);
                if (stuff == null)
                    return;
                this.Dispatcher.BeginInvoke(new Action(() => 
                {


                    last_message = stuff.Message;
                    name = stuff.Name;
                    AvatarImage = stuff.AvatarImage;

                    if (xchat.Items.Count == 0)
                    {



                        MsgBox mgb_ = new MsgBox();
                        mgb_.NameUser = name;
                        mgb_.AddNewText(last_message);
                        Console.WriteLine(AvatarImage);
                        mgb_.SetAvatarImage((string)AvatarImage);
                        xchat.Items.Add(mgb_);

                    }
                    else if (xchat.Items.Count > 0)
                    {
                        MsgBox msgBox = xchat.Items[xchat.Items.Count-1] as MsgBox;
                        if(msgBox.NameUser == name && DATE.GetTime() == msgBox.DateTime)
                        {
                            msgBox.AddNewText(last_message);
                        }
                        else
                        {
                            MsgBox mgb_ = new MsgBox();
                            mgb_.NameUser = name;
                            mgb_.AddNewText(last_message);
                            mgb_.SetAvatarImage((string)AvatarImage);
                            xchat.Items.Add(mgb_);
                        }
                    }
                }));   
            };
        }

        private void CuTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                webSocket.SendMessage((sender as CuTextBox).Text);
                (sender as CuTextBox).Text = "";
            }
        }
 
        private void profile_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;
             
                User.Name = profile_name.Text;
                UpdateProfile();

             
           
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            switch (ProfileSetting.Visibility)
            {
                case Visibility.Visible:
                    ProfileSetting.Visibility = Visibility.Hidden;
                    break;
                case Visibility.Hidden:
                    ProfileSetting.Visibility = Visibility.Visible;
                    break;
                case Visibility.Collapsed:
                    break;
                default:
                    break;
            }
        }

        private void profile_name_KeyDown2(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;
            User.LinkAvatarImage = imagelink.Text;
            UpdateProfile();
        }

        private void iphost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;
            webSocket.WebSocketHost = iphost.Text;
            webSocket.Close();
            webSocket.Init();
            UpdateProfile();
        }
    }
}
