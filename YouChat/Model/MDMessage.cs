using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace YouChat.Model
{
    public class MDMessage : INotifyPropertyChanged
    {
        private string _MsgContent;

        public string MsgContent
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this._MsgContent))
                    this._MsgContent = "Hello!";
                return this._MsgContent;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this._MsgContent = value;
                    CallNotifyPropertyChange("MsgContent");
                }
            }
        }

        private bool _IsFromMe = false;

        public bool IsFromMe
        {
            get { return _IsFromMe; }
            set { _IsFromMe = value; }
        }

        public HorizontalAlignment HorizontalAlignment
        {
            get
            {
                if (this.IsFromMe)
                    return System.Windows.HorizontalAlignment.Right;
                else return System.Windows.HorizontalAlignment.Left;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void CallNotifyPropertyChange(string PropertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}
