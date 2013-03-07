using System.Collections.Generic;

namespace StarcraftUnits.Models
{
    public class Unit
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public int HitPoints { get; set; }
        public int Minerals { get; set; }
        public int Gas { get; set; }
        public int Time { get; set; }
        public float GroundDps { get; set; }
        public float AirDps { get; set; }
        public float Speed { get; set; }
        public IList<string> Counters { get; set; }
        public string BuiltFrom { get; set; }
    }
}