using System.ComponentModel;

namespace BlueNotify.Models
{
    public class ExplorerView : INotifyPropertyChanged
    {
        private string request = "";
        public string Request
        {
            get
            {
                return request;
            }
            set
            {
                request = value;
                OnPropertyChanged(nameof(Request));
            }
        }

        private string response = "";
        public string Response
        {
            get
            {
                return response;
            }
            set
            {
                response = value;
                OnPropertyChanged(nameof(Response));
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
