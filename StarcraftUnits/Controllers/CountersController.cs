using System.Collections.Generic;
using System.Web.Http;

namespace StarcraftUnits.Controllers
{
    public class CountersController : ApiController
    {
        public IList<string> GetCountersFor(string id)
        {
            var list = new List<string>();
            switch (id)
            {
                case "Stalker":
                    list.Add("Marauder");
                    break;
                case "Marine":
                    list.Add("Baneling");
                    break;
                case "Carrier":
                    list.Add("More Carriers");
                    break;
                default:
                    list.Add("Marine");
                    break;
            }
            return list;
        }
    }
}
