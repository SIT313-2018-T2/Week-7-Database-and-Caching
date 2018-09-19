using SQLite;

namespace CFSessionDB.Model
{
   public class Session
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        public string SessionTitle { get; set; }

        public string SessionDescription { get; set; }

        public Session(){
        }

        public Session(string SessionTitle, string SessionDescription)
        {
            this.SessionTitle = SessionTitle;
            this.SessionDescription = SessionDescription;
        }
    }
}
