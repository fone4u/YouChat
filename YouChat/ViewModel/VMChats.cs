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

        private ICommunicate Communicater = new CommunicaterForTest();

        public VMChats()
        {
            Communicater.SomeThingHappen += Communicater_SomeThingHappen;
        }

        public void Communicater_SomeThingHappen(object sender, EventCommunicateArgs e)
        {
            Messages.Add(new MDMessage() { IsFromMe = false, MsgContent = e.MessageContent });
        }


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

        public event EventHandler SendMessageComplete;

        public void SendMessage(string StrMsg)
        {
            MDMessage msg = new Model.MDMessage() { MsgContent = StrMsg, IsFromMe = true };
            Messages.Add(msg);
            Communicater.SendMessageOK += Communicater_SendMessageOK;
            Communicater.Send(msg);            
        }

        private void Communicater_SendMessageOK(object sender, EventArgs e)
        {
            if (SendMessageOK != null)
                SendMessageOK(null, null);
        }

        public event EventHandler SendMessageOK;
    }


    public class ChatMessageEventArgs : EventArgs
    {
        public string Msg { get; set; }
    }

}
