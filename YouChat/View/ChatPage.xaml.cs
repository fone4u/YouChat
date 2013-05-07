using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using YouChat.ViewModel;
namespace YouChat.View
{
    public partial class ChatPage : PhoneApplicationPage
    {
        public VMChats vm;

        public ChatPage()
        {
            InitializeComponent();
            vm = new VMChats();
            vm.GetMessages(18);
            this.lstBxChats.DataContext = vm.Messages;
            if (lstBxChats.Items.Count > 0)
                lstBxChats.ScrollIntoView(lstBxChats.Items.Last()); //todo 这里滚动不完美
        }

        private void btn_send_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_msg.Text)) return;
            
            vm.SendMessageOK += (o, ee) =>
                {
                    // 显示发送成功，或弄一个对勾，或仿照短信和微信：“噗”的一声

                };

            vm.SendMessage(tbx_msg.Text);

            lstBxChats.ScrollIntoView(lstBxChats.Items.Last()); //todo 这里滚动不完美
            tbx_msg.Text = "";
        }

        private void tbx_msg_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //todo 也许这里有bug，可能会出现用户输入“请输入内容....”的情况，但暂时先不考虑
            if (tbx_msg.Text == "请输入内容....")
                tbx_msg.Text = "";
        }
    }
}