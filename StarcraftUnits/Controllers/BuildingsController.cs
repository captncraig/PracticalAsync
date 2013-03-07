using System.Web.Http;

namespace StarcraftUnits.Controllers
{
    public class BuildingsController : ApiController
    {
        // /Buildings/Marine
        public string GetBuiltFrom(string id)
        {
            switch (id)
            {
                case "Stalker":
                case "Zealot":
                    return "Gateway";
                case "Marine":
                case "Marauder":
                    return "Barracks";
                case "Zergling":
                    return "Hatchery";
                case "Baneling":
                    return "Zergling";
                case "Carrier":
                    return "Stargate";
                default:
                    return "Unknown";
            }
        }
    }
}
