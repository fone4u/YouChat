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
using YouChat.Model;

namespace YouChat.View
{
    public partial class FriendsListPage : PhoneApplicationPage
    {
        private VMFriends vm;

        public FriendsListPage()
        {
            InitializeComponent();
            vm = new VMFriends();
            InitFriendsList();
        }

        public void InitFriendsList()
        {
            vm.GetFriends(16);
            lstBxFirends.DataContext = vm.Friends;
        }

        private void FriendStackPanel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {            
            StackPanel sp = sender as StackPanel;
            if (sp == null) return;

            MDFriend friend = sp.DataContext as MDFriend;
            if (friend == null) return;

            if (this.NavigationService == null) return;
            this.NavigationService.Navigate(new Uri("/View/ChatPage.xaml", UriKind.Relative));
        }
    }
}