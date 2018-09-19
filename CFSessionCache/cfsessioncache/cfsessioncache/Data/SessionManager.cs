using CFSessionCache.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace CFSessionCache.Data
{
    public class SessionsManager
    {
        //Declare HTTP Client
        HttpClient client = new HttpClient();
        //A list property to maintain the sessions datat
        List<Session> ConferenceSessions = null;
        //This is an async method get the session data through accessing the Web API
        public async Task<List<Session>> FetchSessionsAsync()
        {
            string url = "http://192.168.1.105:8080/api/conferencesessions";
            try
            {
                var response = await client.GetAsync(url);
                //if the http request sucessed, the response code should be 200OK,then get the session data
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    //Convert the Json to real objects
                    ConferenceSessions = JsonConvert.DeserializeObject<List<Session>>(content);
                }
            }
            //if the web aip reply a non 200 OK response and can catch it. 
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return ConferenceSessions;
        }


    }
}