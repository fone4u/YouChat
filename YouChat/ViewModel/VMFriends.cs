using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using YouChat.Model;

namespace YouChat.ViewModel
{
    public class VMFriends
    {
        public ObservableCollection<MDFriend> Friends;

        public void GetFriends(int number)
        {
            Friends = new ObservableCollection<MDFriend>();
            for (int i = 0; i < number; i++)
            {
                Friends.Add(new MDFriend() { Name = "Friend---" + i.ToString() });
            }
        }
    }
}
