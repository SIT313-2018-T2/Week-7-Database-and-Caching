using Akavache;
using CFSessionCache.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CFSessionCache.Data
{
    public class AppCache
    {
        IBlobCache Cache = null;

        public AppCache()
        {
            Cache = BlobCache.LocalMachine;
        }

        public event PropertyChangedEventHandler SessionsCacheChanged;

        public async Task GetAllSessionsAsync()
        {
            var cachedSessions = Cache.GetOrFetchObject<List<Session>>(
                            "AllSessions",
                async () => await (new SessionsManager()).FetchSessionsAsync(), DateTimeOffset.Now.AddHours(3)
            ).Subscribe((List<Session> obj) =>

                        SessionsCacheChanged(obj,
                                  new PropertyChangedEventArgs("SessionsCache"))
                       );
        }
    }
}
