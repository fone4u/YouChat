using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using YouChat.Model;

namespace YouChat.Tools
{
    public class CommunicaterForTest : ICommunicate
    {
        public CommunicaterForTest()
        {
            //Thread energyThread = new Thread(new ThreadStart(Heartbeat));//创建一个线程  
            //energyThread.Start();//启动  
        }
        
        public void Send(MDMessage msg)
        {
            // todo 这里应该定时跟后台进行通讯，并且是多线程的，在后台线程运行，发生时通知给前台
            WebClientSimulater csft = new WebClientSimulater();
            csft.SendCompeleted += csft_SendCompeleted;
            csft.Send(msg.MsgContent);            
        }

        private void csft_SendCompeleted(object sender, WebClientSimulaterEventArgs e)
        {
            if (SomeThingHappen != null)
            {
                SomeThingHappen(this, new EventCommunicateArgs() { MessageType = ChatMessageTypes.NewMessageFormOther, MessageContent = e.Msg });
            }

            if (SendMessageOK != null)
                SendMessageOK(null, null);
        }

        public void Heartbeat()
        {
            Thread.Sleep(5000);
            if (SomeThingHappen != null)
            {
                SomeThingHappen(this, new EventCommunicateArgs() { MessageType= ChatMessageTypes.NewMessageFormOther, MessageContent="在吗，干嘛呢？"});
            }
        }

        public event EventHandler<EventCommunicateArgs> SomeThingHappen;

        public event EventHandler SendMessageOK;
    }
}
