using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace YouChat.Tools
{
    public class WebClientSimulater
    {
        public event EventHandler<WebClientSimulaterEventArgs> SendCompeleted;

        private void FireSendCompeleted(string msg)
        {
            string backMsg = msg.Replace("我", "你");
            backMsg = backMsg.Replace("你", "我");

            if(SendCompeleted != null)
                SendCompeleted(null, new WebClientSimulaterEventArgs() { Msg = "是啊，我也觉得" + backMsg + "~ 还有呢？" });
            return;
        }

        public void Send(string msg)
        {
            //Thread energyThread = new Thread(new ThreadStart(
            //        () =>
            //        {
            //            Thread.Sleep(500);
            //            FireSendCompeleted(msg);
            //        }
            //    ));//创建一个线程
            //为什么线程在这里不能用呢？
            FireSendCompeleted(msg);

        }
    }

    public class WebClientSimulaterEventArgs : EventArgs
    {
        public string Msg { get; set; } 
    }
}
