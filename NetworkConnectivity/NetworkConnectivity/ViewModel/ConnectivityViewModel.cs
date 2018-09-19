using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using System.ComponentModel;


namespace NetworkConnectivity.ViewModel
{
    public class ConnectivityViewModel : INotifyPropertyChanged
    {
        string _connectionStatus ="";
        public event PropertyChangedEventHandler PropertyChanged;

        public string ConnectionStatus
        {
            get { return _connectionStatus; }
            set
            {
                _connectionStatus = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ConnectionStatus"));

            }
        }
        public ConnectivityViewModel()
        {
            UpdateConnectionStatus();
            CrossConnectivity.Current.ConnectivityChanged +=
                                 (sender, e) =>
            {
                this.UpdateConnectionStatus();

            };
                             
        }

        void UpdateConnectionStatus()
        {
            if (CrossConnectivity.Current != null && CrossConnectivity.Current.IsConnected == true)
            {
                var str = "";
                foreach (ConnectionType type in CrossConnectivity.Current.ConnectionTypes)
                    str += type.ToString() + " ";
                ConnectionStatus = string.Format("Connected to {0}", str);
            }
            else
            {
                ConnectionStatus = "Not connected!";
            }
        }
    }
}
