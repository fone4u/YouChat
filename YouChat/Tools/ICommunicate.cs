using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouChat.Tools
{
    public interface ICommunicate
    {
        bool Send(Action callback);
        event EventHandler SomeThingHappen;
        void Heartbeat();        
    }
}
