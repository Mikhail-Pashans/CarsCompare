using Newtonsoft.Json;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CarsCompare.Domain")]
namespace CarsCompare.Database.Models
{
    public abstract class Base : IntPrimaryKey
    {
        [JsonIgnore]
        public int DatabaseVersion { get; set; }
        
        [JsonIgnore]
        public int ItemType { get; set; }
    }
}