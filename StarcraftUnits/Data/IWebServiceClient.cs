using System.Collections.Generic;

namespace StarcraftUnits.Data
{
    public interface IWebServiceClient
    {
        string BuiltFrom(string name);
        IList<string> GetCountersFor(string name);
    }
}