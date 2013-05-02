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
        }
    }
}