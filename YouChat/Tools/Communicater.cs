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
            if (this.SomeThingHappen != null)
                this.SomeThingHappen(null, null);
        }
    }
}
