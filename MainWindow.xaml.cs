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
using System.Net;
using System.Threading;
using System.Net.Sockets;

namespace Lula
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
   
    public partial class MainWindow : Window
    {
        private static Encoding encode = Encoding.Default;
        IPAddress ipAddress;
        Socket mysocket;
        public MainWindow()
        {
            InitializeComponent();
            ipAddress = IPAddress.Parse("192.168.0.107");
            mysocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private void UserPasswdInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Login_button_Click(object sender, RoutedEventArgs e)
        {
            if (UserIDInput.Text == null || UserIDInput.Text == "")
            {
                Tip_label.Content = "请输入用户ID";
            }else if (UserPasswdInput.Text == null || UserPasswdInput.Text == "")
            {
                Tip_label.Content = "请输入密码";
            }
            else
            {
                String User_id = UserIDInput.Text;
                String User_passwd = UserPasswdInput.Text;
                try
                {
                    mysocket.Connect(new IPEndPoint(ipAddress, 1900)); //配置服务器IP与端口
                    Tip_label.Content = ("连接服务器成功");
                    mysocket.Send(encode.GetBytes("-"+User_passwd+"-"+User_id+"\n"));
                }
                catch
                {
                    Tip_label.Content = "链接错误";
                }

            }
            
            
        }
    }
}
