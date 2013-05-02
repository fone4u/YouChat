using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using YouChat.Model;
using YouChat.Tools;

namespace YouChat.ViewModel
{
    public class VMChats
    {
        public ObservableCollection<MDMessage> Messages;

        public event EventHandler<ChatMessageEventArgs> NewMessageArrived;

        private ICommunicate Communicater;


        public void GetMessages(int number)
        {
            if (Messages == null) Messages = new ObservableCollection<MDMessage>();

            bool IsFromMe = true;
            for (int i = 0; i < number; i++)
            {
                IsFromMe = !IsFromMe;
                Messages.Add(new MDMessage() { MsgContent = "你好啊~！" + i.ToString(), IsFromMe = IsFromMe });
            }
        }
        
    }


    public class ChatMessageEventArgs : EventArgs
    {
        public string Msg { get; set; }
    }

}
