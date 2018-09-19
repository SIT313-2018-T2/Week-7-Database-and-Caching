using CFSessionDB.Model;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CFSessionDB.Data;

namespace CFSessionDB.ViewModel
{
    public class SessionListViewModel : INotifyPropertyChanged
    {
        Database _database = new Database();
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Session> _sessionslist;

        public ObservableCollection<Session> SessionsList
        {
            get { return _sessionslist; }
            set
            {
                _sessionslist = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SessionsList"));
                
            }
        }
        public async Task FetchDataAsync()
        {
            var list = await _database.GetAllSessionAsync();
            SessionsList = new ObservableCollection<Session>(list);

        }
        public SessionListViewModel()
        {
            FetchDataAsync();
        }
        
    }
}