using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ServiceStack.ServiceClient.Web;

namespace StarcraftUnits.Data
{
    public interface IWebServiceClient
    {
        Task<string> BuiltFrom(string name);
        Task<IList<string>> GetCountersFor(string name);
    }

    class WebServiceClient : IWebServiceClient
    {
        private const string Url = "http://localhost:49865/api/";


        public async Task<string> BuiltFrom(string name)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(Url + "buildings/" + name);
            var content = await response.Content.ReadAsStringAsync();
            return content.Trim('"');
        }

        public async Task<IList<string>> GetCountersFor(string name)
        {
            var client = new JsonServiceClient(Url);
            return client.Get<List<string>>("/counters/" + name);
        }
    }
}