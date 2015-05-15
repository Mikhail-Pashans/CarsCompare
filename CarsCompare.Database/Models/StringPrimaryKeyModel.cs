using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CarsCompare.Domain")]
namespace CarsCompare.Database.Models
{
    public abstract class StringPrimaryKeyModel
    {
        public string Id { get; set; }
    }
}