using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueNotify.Models
{
    public class NotificationHubParameters : INotifyPropertyChanged
    {
        private string hubName = "";
        public string HubName { 
            get {
                return hubName; 
            } 
            set {
                hubName = value;
                OnPropertyChanged(nameof(HubName));
            } 
        }

        private string hubUrl = "";
        public string HubUrl {
            get
            {
                return hubUrl;
            }
            set
            {
                hubUrl = value;
                OnPropertyChanged(nameof(HubUrl));
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
