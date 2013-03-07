using System.Collections.Generic;
using ServiceStack.ServiceClient.Web;

namespace StarcraftUnits.Data
{
    class WebServiceClient : IWebServiceClient
    {
        private const string Url = "http://localhost:49865/api/";

        public IList<string> GetCountersFor(string name)
        {
            var client = new JsonServiceClient(Url);
            return client.Get<List<string>>("/counters/" + name);
        }
    }
}