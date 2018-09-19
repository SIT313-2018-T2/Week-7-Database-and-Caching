using CFSessionCache.Model;
using CFSessionCache.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CFSessionCache.ViewModel
{
    public class SessionListViewModel : INotifyPropertyChanged
    {
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
            var AppCache = new AppCache();
            AppCache.SessionsCacheChanged +=
                (sender, e) => { SessionsList = new ObservableCollection<Session>((List<Session>)sender); };
            await AppCache.GetAllSessionsAsync();

        }
        public SessionListViewModel()
        {
            FetchDataAsync();
        }
    }
}
