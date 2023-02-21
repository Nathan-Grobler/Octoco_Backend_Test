using System.Collections.Generic;
using System.Reflection;

namespace octoco_backend_test
{
    public class Survivor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get;set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Dictionary<string, int>? Inventory { get; set; }
        // name, age, gender and last location(latitude/longitude).
    }
}
