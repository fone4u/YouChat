using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouChat.Model;

namespace YouChat.Tools
{
    public interface ICommunicate
    {
        void Send( MDMessage msg);
        event EventHandler SendMessageOK;
        event EventHandler<EventCommunicateArgs> SomeThingHappen;
        void Heartbeat();
    }

    public enum ChatMessageTypes
    {
        MessageSendReport,   //发送报告
        NewMessageFormOther, //好友消息
        NewMessageFormSystem //系统消息
    }

    public class EventCommunicateArgs : EventArgs
    {
        public ChatMessageTypes MessageType { get; set; }
        public string MessageContent { get; set; }
    }
}
