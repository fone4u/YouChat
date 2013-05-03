using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouChat.Tools
{
    public class Communicater : ICommunicate
    {

        public bool Send(Action callback)
        {
            if (callback != null)
                callback();
            return true;
        }

        public event EventHandler SomeThingHappen;

        public void Heartbeat()
        {
            //todo 这里应该定时跟后台进行通讯，并且是多线程的，在后台线程运行，发生时通知给前台

            if (this.SomeThingHappen != null)
                this.SomeThingHappen(null, null);
        }
    }
}
