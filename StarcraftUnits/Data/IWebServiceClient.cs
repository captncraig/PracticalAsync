using System.Collections.Generic;

namespace StarcraftUnits.Data
{
    public interface IWebServiceClient
    {
        IList<string> GetCountersFor(string name);
    }
}