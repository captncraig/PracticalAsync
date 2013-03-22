using System.Collections.Generic;
using System.Net;
using ServiceStack.ServiceClient.Web;

namespace StarcraftUnits.Data
{
    public interface IWebServiceClient
    {
        string BuiltFrom(string name);
        IList<string> GetCountersFor(string name);
    }

    class WebServiceClient : IWebServiceClient
    {
        private const string Url = "http://localhost:49865/api/";


        public string BuiltFrom(string name)
        {
            var client = new WebClient();
            return client.DownloadString(Url + "buildings/" + name).Trim('"');
        }

        public IList<string> GetCountersFor(string name)
        {
            var client = new JsonServiceClient(Url);
            return client.Get<List<string>>("/counters/" + name);
        }
    }
}