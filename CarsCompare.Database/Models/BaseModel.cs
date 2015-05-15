using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CarsCompare.Domain")]
namespace CarsCompare.Database.Models
{
    public abstract class BaseModel : IntPrimaryKeyModel
    {
        public int DatabaseVersion { get; set; }
        
        public int ItemType { get; set; }
    }
}