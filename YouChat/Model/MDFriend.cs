using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YouChat.Model
{
    public class MDFriend : INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this._name))
                    this._name = "Default Friend";
                return this._name;
            }
            set
            {
                if(!string.IsNullOrWhiteSpace(value))
                {
                    this._name = value;
                    CallNotifyPropertyChange("Name");
                }
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
